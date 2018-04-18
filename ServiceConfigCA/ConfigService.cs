using HomeCloudWindows;
using Microsoft.Deployment.WindowsInstaller;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ServiceConfigCA
{
    public partial class ConfigService : Form
    {

        private static string folderSelectResult;
        private static string folderSelectPath;

        public ConfigService(Session session)
        {
            InitializeComponent();
            TopMost = true;

            textBoxSyncFolder.BackColor = System.Drawing.SystemColors.Info;
            textBoxSyncFolder.ReadOnly = true;
        }

        private void btnSelectSyncFolder_Click(object sender, EventArgs e)
        {
            TopMost = false;
            Thread worker = new Thread(() =>
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                DialogResult result = dialog.ShowDialog();
                folderSelectResult = result == DialogResult.OK ? "OK" : "KO";
                if (result == DialogResult.OK)
                {
                    folderSelectPath = dialog.SelectedPath;
                }
            });
            worker.SetApartmentState(ApartmentState.STA);
            worker.Start();
            worker.Join();
            if (folderSelectResult == "OK")
            {
                textBoxSyncFolder.Text = folderSelectPath;
            }
            TopMost = true;
        }

        private void textBoxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void ConfigService_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (! Validations())
            {
                e.Cancel = true;
                return;
            }
            SaveInformation();
        }

        private void SaveInformation()
        {
            // store config values in settings
            InMemoryConfig config = InMemoryConfig.Instance;
            config._port = int.Parse(textBoxPort.Text);
            config._syncFolder = textBoxSyncFolder.Text;
            config._password = HashUtil.MD5Hash(textBoxPassword.Text);
            config.SaveRegKey();
        }

        private bool Validations()
        {
            if (DialogResult == DialogResult.Cancel)
                return true;

            // validations
            if (String.IsNullOrEmpty(textBoxSyncFolder.Text))
            {
                MessageBox.Show("The sync folder cannot be empty");
                return false;
            }
            if (! Directory.Exists(textBoxSyncFolder.Text))
            {
                MessageBox.Show($"The folder {textBoxSyncFolder.Text} does not exist");
                return false;
            }
            if (! IsDirectoryEmpty(textBoxSyncFolder.Text))
            {
                MessageBox.Show($"The sync folder must be empty");
                return false;
            }
            if (String.IsNullOrEmpty(textBoxPort.Text))
            {
                MessageBox.Show("The port cannot be empty");
                return false;
            }
            if (!int.TryParse(textBoxPort.Text, out int n)
                || int.Parse(textBoxPort.Text) < 1
                || int.Parse(textBoxPort.Text) > 65535)
            {
                MessageBox.Show("The port should be a number between 1 and 65535");
                return false;
            }
            if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("The password cannot be empty");
                return false;
            }
            if (textBoxPassword.Text.Length > 8 || textBoxPassword.Text.Length < 3)
            {
                MessageBox.Show("The password lenght must be between 3 and 8 characters");
                return false;
            }
            if (textBoxPassword.Text != textBoxPasswordRepeat.Text)
            {
                MessageBox.Show("The passwords do not match");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to cancel HomeCloud installation?",
                    "Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                DialogResult = DialogResult.Cancel;
        }

        private bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
    }
}
