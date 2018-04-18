using HomeCloudWindows;
using System;
using System.IO;
using System.Net;
using System.ServiceModel.Web;

namespace HomeCloudService
{
    class SyncService : ISyncService
    {
        private void ValidateUser(String token)
        {
            var config = InMemoryConfig.Instance;
            if (! config.CheckTokenExists(token))
            {
                throw new WebFaultException(HttpStatusCode.Forbidden);
            }
        }

        public void PostImage(string imageBase64, string token, string fileName, string folderName, string lastModified, string idPart)
        {
            ValidateUser(token);

            var config = InMemoryConfig.Instance;
            
            if (! String.IsNullOrEmpty(idPart))
            {
                if (String.IsNullOrEmpty(imageBase64))
                {
                    // end of sending, get the whole buffer
                    imageBase64 = InMemoryFileBuffer.Instance.GetBuffer(token, idPart);
                }
                else
                {
                    // add to buffer, we do not need to do anymore
                    InMemoryFileBuffer.Instance.AddBuffer(token, idPart, imageBase64);
                    return;
                }
            }

            if (String.IsNullOrEmpty(folderName))
            {
                File.WriteAllBytes($"{config.GetFolder(token)}\\{fileName}", Convert.FromBase64String(imageBase64));
            }
            else
            {
                Directory.CreateDirectory($"{config.GetFolder(token)}\\{folderName}");
                File.WriteAllBytes($"{config.GetFolder(token)}\\{folderName}\\{fileName}", Convert.FromBase64String(imageBase64));
            }
            

            config.Sync(token, lastModified);
        }

        public string Login(string userName, string password)
        {
            var config = InMemoryConfig.Instance;

            if (string.IsNullOrEmpty(password) || ! HashUtil.MD5Hash(password).Equals(config._password))
            {
                throw new WebFaultException(HttpStatusCode.Forbidden);
            }

            string token = config.GetToken(userName);

            // create the folder if it does not exist
            Directory.CreateDirectory($"{config.GetFolder(token)}");

            return token;
        }

        public string GetLastSync(string token)
        {
            ValidateUser(token);

            var config = InMemoryConfig.Instance;

            return config.GetLastSync(token);
        }
    }
}
