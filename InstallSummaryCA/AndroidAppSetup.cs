using HomeCloudWindows;
using Microsoft.Deployment.WindowsInstaller;
using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace InstallSummaryCA
{
    public partial class AndroidAppSetup : Form
    {
        public AndroidAppSetup(Session session)
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AndroidAppSetup_Load(object sender, EventArgs e)
        {
            InMemoryConfig config = InMemoryConfig.Instance;
            config.LoadRegKey();
            labelPort.Text = config._port.ToString();
            labelIp.Text = GetIp();
        }

        private String GetIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return String.Empty;
        }

    }
}
