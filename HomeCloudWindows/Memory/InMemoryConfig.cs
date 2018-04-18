using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;

namespace HomeCloudWindows
{
    public sealed class InMemoryConfig
    {

        public static InMemoryConfig Instance { get; } = new InMemoryConfig();

        #region constants
        private const string DEFAULT_PORT = "3999";
        private const string DEFAULT_SYNC_FOLDER = "c:\\Sync";
        private const string DEFAULT_PASSWORD = "planetludus";
        private const string LAST_SYNC_SUFFIX = "_lastSync";
        private const string CONF_PORT = "port";
        private const string CONF_SYNC_FOLDER = "syncFolder";
        private const string CONF_PASSWORD = "password";
        private const string REG_KEY = @"Software\HomeCloudWS";
        #endregion

        public int _port { set; get; }
        public string _syncFolder { set; get; }
        public string _password { set; get; }
        public long _maxBufferPoolSize { get; }
        public long _maxReceivedMessageSize { get; }
        public int _maxBufferSize { get; }

        private Dictionary<string, KeyValuePair<String, TokenData>> tokenInformation;
        private CultureInfo provider = CultureInfo.InvariantCulture;
        private Configuration configFile;

        public void UpdateConfig(bool saveKeys)
        {
            foreach (KeyValuePair<string, KeyValuePair<string, TokenData>> entry in tokenInformation)
            {
                SetUserLastSyncFromProp(entry.Value.Key, entry.Value.Value.LastSyncDate);
            }

            if (saveKeys)
            {
                SaveRegKey();
            }
            configFile.Save();
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        public string GetToken(string userName)
        {
            string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            // check if the user already has a token and remove it (there should be only one)
            var oldToken = tokenInformation.Where(i => i.Value.Key == userName).Select(x => x.Key);
            DateTime lastSyncDate;
            if (oldToken != null && oldToken.Any())
            {
                // we have to maintain the lastSync
                lastSyncDate = GetTokenDataFromToken(oldToken.First()).LastSyncDate;
                oldToken.ToList().ForEach(currentToken => tokenInformation.Remove(currentToken));
            }
            else
            {
                lastSyncDate = GetUserLastSyncFromProp(userName);
            }

            tokenInformation.Add(token, new KeyValuePair<string, TokenData>(
                userName
                , new TokenData(
                    DateTime.Now
                    , lastSyncDate
                    , $"{_syncFolder}\\{userName}")
                )
            );

            return token;
        }

        public void Sync(string token, string lastModified)
        {
            GetTokenDataFromToken(token).LastSyncDate = FromStrToDate(lastModified);
        }

        public string GetFolder(string token)
        {
            return GetTokenDataFromToken(token).SyncFolder;
        }

        public string GetLastSync(string token)
        {
            return FromDateToStr(GetTokenDataFromToken(token).LastSyncDate);
        }
    
        public bool CheckTokenExists(string token)
        {
            return tokenInformation.TryGetValue(token, out KeyValuePair<string, TokenData> tokenData);
        }

        [RegistryPermissionAttribute(SecurityAction.Assert, Read = REG_KEY)]
        public void LoadRegKey()
        {
            RegistryKey appKey = GetRegistryKey().OpenSubKey(REG_KEY);

            if (appKey != null)
            {
                _port = (int)appKey.GetValue(CONF_PORT);
                _syncFolder = (string)appKey.GetValue(CONF_SYNC_FOLDER);
                _password = (string)appKey.GetValue(CONF_PASSWORD);

                appKey.Close();
            }
        }

        [RegistryPermissionAttribute(SecurityAction.Assert, Create = REG_KEY)]
        public void SaveRegKey()
        {
            RegistryKey appKey = GetRegistryKey().CreateSubKey(REG_KEY);

            appKey.SetValue(CONF_PORT, _port);
            appKey.SetValue(CONF_SYNC_FOLDER, _syncFolder);
            appKey.SetValue(CONF_PASSWORD, _password);

            appKey.Close();
        }

        [RegistryPermissionAttribute(SecurityAction.Assert, ViewAndModify = REG_KEY)]
        public void DeleteRegKey()
        {
            GetRegistryKey().DeleteSubKey(REG_KEY);
        }

        private class TokenData
        {
            public DateTime CreationDate { get; set; }
            public DateTime LastSyncDate { get; set; }
            public String SyncFolder { get; set; }

            public TokenData(DateTime creationDate, DateTime lastSyncDate, String syncFolder)
            {
                this.CreationDate = creationDate;
                this.LastSyncDate = lastSyncDate;
                this.SyncFolder = syncFolder;
            }
        }

        private RegistryKey GetRegistryKey()
        {
            return RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
        }

        private InMemoryConfig()
        {
            // load config
            configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // initialize token and token information
            tokenInformation = new Dictionary<string, KeyValuePair<string, TokenData>>();

            // load other properties
            string httpBindingMaxBufferPoolSize = ReadConfProperty("httpBinding_maxBufferPoolSize", String.Empty);
            if (! String.IsNullOrEmpty(httpBindingMaxBufferPoolSize))
            {
                _maxBufferPoolSize = long.Parse(httpBindingMaxBufferPoolSize);
            }

            string httpBindingMaxReceivedMessageSize = ReadConfProperty("httpBinding_maxReceivedMessageSize", String.Empty);
            if (! String.IsNullOrEmpty(httpBindingMaxReceivedMessageSize))
            {
                _maxReceivedMessageSize = long.Parse(httpBindingMaxReceivedMessageSize);
            }

            string httpBindingMaxBufferSize = ReadConfProperty("httpBinding_maxBufferSize", String.Empty);
            if (! String.IsNullOrEmpty(httpBindingMaxBufferSize))
            {
                _maxBufferSize = int.Parse(httpBindingMaxBufferSize);
            }
        }

        private string ReadConfProperty(string property, string defaultValue)
        {
            string value = Properties.Settings.Default[property] as string;
            return value ?? defaultValue;
        }

        private string GetUserLastSyncPropName(string userName)
        {
            return $"{userName}{LAST_SYNC_SUFFIX}";
        }

        private DateTime GetUserLastSyncFromProp(string userName)
        {
            string lastSync;
            try
            {
                lastSync = configFile.AppSettings.Settings[GetUserLastSyncPropName(userName)].Value;
            }
            catch (Exception)
            {
                lastSync = String.Empty;
            }
            return FromStrToDate(lastSync);
        }

        private void SetUserLastSyncFromProp(string userName, DateTime datetime)
        {
            configFile.AppSettings.Settings.Add(GetUserLastSyncPropName(userName), FromDateToStr(datetime));
        }

        private DateTime FromStrToDate(string dateStr)
        {
            if (String.IsNullOrEmpty(dateStr))
            {
                return DateTime.MinValue;
            }
            return DateTime.ParseExact(dateStr, Properties.Settings.Default.dateTimeFormat, provider);
        }

        private string FromDateToStr(DateTime dateTime)
        {
            if (dateTime == null)
            {
                return String.Empty;
            }
            return dateTime.ToString(Properties.Settings.Default.dateTimeFormat, provider);
        }

        private TokenData GetTokenDataFromToken(string token)
        {
            if (!tokenInformation.TryGetValue(token, out KeyValuePair<string, TokenData> keyValue))
            {
                throw new Exception("Token not found");
            }
            return keyValue.Value;
        }
    }
}
