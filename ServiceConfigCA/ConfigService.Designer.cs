namespace ServiceConfigCA
{
    partial class ConfigService
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigService));
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbSelectFolder = new System.Windows.Forms.Label();
            this.syncFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectSyncFolder = new System.Windows.Forms.Button();
            this.textBoxSyncFolder = new System.Windows.Forms.TextBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.lbSyncFolderExp = new System.Windows.Forms.Label();
            this.lbPortExp = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbRepeat = new System.Windows.Forms.Label();
            this.textBoxPasswordRepeat = new System.Windows.Forms.TextBox();
            this.lbPasswordExp = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lbPortRange = new System.Windows.Forms.Label();
            this.lbPasswordRange = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(13, 13);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(255, 29);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Service Configuration";
            // 
            // lbSelectFolder
            // 
            this.lbSelectFolder.AutoSize = true;
            this.lbSelectFolder.Location = new System.Drawing.Point(18, 109);
            this.lbSelectFolder.Name = "lbSelectFolder";
            this.lbSelectFolder.Size = new System.Drawing.Size(60, 13);
            this.lbSelectFolder.TabIndex = 1;
            this.lbSelectFolder.Text = "Sync folder";
            // 
            // syncFolderBrowserDialog
            // 
            this.syncFolderBrowserDialog.SelectedPath = "C:\\Sync";
            // 
            // btnSelectSyncFolder
            // 
            this.btnSelectSyncFolder.Location = new System.Drawing.Point(269, 104);
            this.btnSelectSyncFolder.Name = "btnSelectSyncFolder";
            this.btnSelectSyncFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectSyncFolder.TabIndex = 2;
            this.btnSelectSyncFolder.Text = "Select...";
            this.btnSelectSyncFolder.UseVisualStyleBackColor = true;
            this.btnSelectSyncFolder.Click += new System.EventHandler(this.btnSelectSyncFolder_Click);
            // 
            // textBoxSyncFolder
            // 
            this.textBoxSyncFolder.Location = new System.Drawing.Point(80, 106);
            this.textBoxSyncFolder.Name = "textBoxSyncFolder";
            this.textBoxSyncFolder.ReadOnly = true;
            this.textBoxSyncFolder.Size = new System.Drawing.Size(172, 20);
            this.textBoxSyncFolder.TabIndex = 1;
            this.textBoxSyncFolder.Text = "C:\\Sync";
            this.textBoxSyncFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(18, 205);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(26, 13);
            this.lbPort.TabIndex = 4;
            this.lbPort.Text = "Port";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(80, 202);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(172, 20);
            this.textBoxPort.TabIndex = 3;
            this.textBoxPort.Text = "3999";
            this.textBoxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPort_KeyPress);
            // 
            // lbSyncFolderExp
            // 
            this.lbSyncFolderExp.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbSyncFolderExp.Location = new System.Drawing.Point(21, 142);
            this.lbSyncFolderExp.Name = "lbSyncFolderExp";
            this.lbSyncFolderExp.Size = new System.Drawing.Size(323, 23);
            this.lbSyncFolderExp.TabIndex = 6;
            this.lbSyncFolderExp.Text = "This is the folder where all the images/videos will be placed";
            // 
            // lbPortExp
            // 
            this.lbPortExp.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbPortExp.Location = new System.Drawing.Point(21, 236);
            this.lbPortExp.Name = "lbPortExp";
            this.lbPortExp.Size = new System.Drawing.Size(323, 46);
            this.lbPortExp.TabIndex = 7;
            this.lbPortExp.Text = "This is the port where the service will be listening. You need to be sure that th" +
    "e port is not being used by other application. If you are not sure, do not chang" +
    "e it.";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(269, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(80, 316);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(172, 20);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(18, 319);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 9;
            this.lbPassword.Text = "Password";
            // 
            // lbRepeat
            // 
            this.lbRepeat.AutoSize = true;
            this.lbRepeat.Location = new System.Drawing.Point(18, 345);
            this.lbRepeat.Name = "lbRepeat";
            this.lbRepeat.Size = new System.Drawing.Size(42, 13);
            this.lbRepeat.TabIndex = 11;
            this.lbRepeat.Text = "Repeat";
            // 
            // textBoxPasswordRepeat
            // 
            this.textBoxPasswordRepeat.Location = new System.Drawing.Point(80, 342);
            this.textBoxPasswordRepeat.Name = "textBoxPasswordRepeat";
            this.textBoxPasswordRepeat.PasswordChar = '*';
            this.textBoxPasswordRepeat.Size = new System.Drawing.Size(172, 20);
            this.textBoxPasswordRepeat.TabIndex = 5;
            this.textBoxPasswordRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbPasswordExp
            // 
            this.lbPasswordExp.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbPasswordExp.Location = new System.Drawing.Point(21, 378);
            this.lbPasswordExp.Name = "lbPasswordExp";
            this.lbPasswordExp.Size = new System.Drawing.Size(323, 46);
            this.lbPasswordExp.TabIndex = 13;
            this.lbPasswordExp.Text = "This is the password that you will need to set in your mobile application";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(177, 440);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lbPortRange
            // 
            this.lbPortRange.AutoSize = true;
            this.lbPortRange.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbPortRange.Location = new System.Drawing.Point(269, 205);
            this.lbPortRange.Name = "lbPortRange";
            this.lbPortRange.Size = new System.Drawing.Size(58, 13);
            this.lbPortRange.TabIndex = 14;
            this.lbPortRange.Text = "[1 - 65535]";
            // 
            // lbPasswordRange
            // 
            this.lbPasswordRange.AutoSize = true;
            this.lbPasswordRange.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbPasswordRange.Location = new System.Drawing.Point(269, 319);
            this.lbPasswordRange.Name = "lbPasswordRange";
            this.lbPasswordRange.Size = new System.Drawing.Size(88, 13);
            this.lbPasswordRange.TabIndex = 15;
            this.lbPasswordRange.Text = "3 to 8 Characters";
            // 
            // ConfigService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 490);
            this.Controls.Add(this.lbPasswordRange);
            this.Controls.Add(this.lbPortRange);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lbPasswordExp);
            this.Controls.Add(this.textBoxPasswordRepeat);
            this.Controls.Add(this.lbRepeat);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbPortExp);
            this.Controls.Add(this.lbSyncFolderExp);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.textBoxSyncFolder);
            this.Controls.Add(this.btnSelectSyncFolder);
            this.Controls.Add(this.lbSelectFolder);
            this.Controls.Add(this.lbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigService";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigService_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog syncFolderBrowserDialog;
        private System.Windows.Forms.Button btnSelectSyncFolder;
        private System.Windows.Forms.TextBox textBoxSyncFolder;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label lbSyncFolderExp;
        private System.Windows.Forms.Label lbPortExp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbRepeat;
        private System.Windows.Forms.TextBox textBoxPasswordRepeat;
        private System.Windows.Forms.Label lbPasswordExp;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lbPortRange;
        private System.Windows.Forms.Label lbPasswordRange;
    }
}