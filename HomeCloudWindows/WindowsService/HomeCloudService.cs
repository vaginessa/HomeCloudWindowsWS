using HomeCloudService;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceProcess;

namespace HomeCloudWindows
{
    public partial class HomeCloudService : ServiceBase
    {
        int port;
        string syncFolder;

        WebServiceHost serviceHost;

        public HomeCloudService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {

                EventLog.WriteEntry("Starting HomeCloud service");

                // config params
                InMemoryConfig memoryConfig = InMemoryConfig.Instance;
                memoryConfig.LoadRegKey();
                port = memoryConfig._port;
                syncFolder = memoryConfig._syncFolder;
                EventLog.WriteEntry($"Input params port: [{port}], directory: [{syncFolder}]");

                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    EventLog.WriteEntry("The network is not available", EventLogEntryType.Warning);
                    return;
                }

                var host = Dns.GetHostEntry(Dns.GetHostName());
                var ipAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                var serverName = Environment.MachineName;
                EventLog.WriteEntry($"Local IP address: [{ipAddress}]. ServerName: [{serverName}]");

                Uri baseAddress = new Uri($"http://{serverName}:{port}");
                Type serviceType = typeof(SyncService);
                serviceHost = new WebServiceHost(serviceType, baseAddress);
                WebHttpBinding binding = new WebHttpBinding
                {
                    MaxBufferPoolSize = memoryConfig._maxBufferPoolSize,
                    MaxReceivedMessageSize = memoryConfig._maxReceivedMessageSize,
                    MaxBufferSize = memoryConfig._maxBufferSize
                };
                serviceHost.AddServiceEndpoint(typeof(ISyncService), binding, "SyncService");
                serviceHost.Open();
                EventLog.WriteEntry($"Listening to http://{serverName}:{port}/SyncService");
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry($"Error stopping the service {ex}: {ex.Message}", EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            try
            {
                EventLog.WriteEntry("Stopping HomeCloud service");

                EventLog.WriteEntry("Saving last sync");
                InMemoryConfig.Instance.UpdateConfig(false);
                if (serviceHost != null)
                {
                    serviceHost.Close();
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry($"Error stopping the service {ex}: {ex.Message}", EventLogEntryType.Error);
            }
        }
    }
}
