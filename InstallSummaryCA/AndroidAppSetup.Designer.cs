namespace InstallSummaryCA
{
    partial class AndroidAppSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AndroidAppSetup));
            this.labelExplanation = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.labelIp = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelFinally = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.AndroidAppScreenshot = new System.Windows.Forms.PictureBox();
            this.lbPassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AndroidAppScreenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // labelExplanation
            // 
            this.labelExplanation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExplanation.Location = new System.Drawing.Point(12, 9);
            this.labelExplanation.Name = "labelExplanation";
            this.labelExplanation.Size = new System.Drawing.Size(549, 61);
            this.labelExplanation.TabIndex = 0;
            this.labelExplanation.Text = "These are the parameters that you need to use in your HomeCloud Android Applicati" +
    "on:\r\n";
            // 
            // labelUserID
            // 
            this.labelUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserID.Location = new System.Drawing.Point(271, 195);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(259, 21);
            this.labelUserID.TabIndex = 2;
            this.labelUserID.Text = "Choose an unique name within your network";
            // 
            // labelIp
            // 
            this.labelIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIp.Location = new System.Drawing.Point(271, 243);
            this.labelIp.Name = "labelIp";
            this.labelIp.Size = new System.Drawing.Size(229, 21);
            this.labelIp.TabIndex = 3;
            // 
            // labelPort
            // 
            this.labelPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPort.Location = new System.Drawing.Point(271, 294);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(229, 19);
            this.labelPort.TabIndex = 4;
            // 
            // labelFinally
            // 
            this.labelFinally.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFinally.Location = new System.Drawing.Point(11, 495);
            this.labelFinally.Name = "labelFinally";
            this.labelFinally.Size = new System.Drawing.Size(543, 84);
            this.labelFinally.TabIndex = 5;
            this.labelFinally.Text = "Write down these values.\r\nNow you can switch \'Synchronize\' button on and enjoy.\r\n" +
    "This program will be running as a background service until you uninstall it or s" +
    "top it from Windows Service.\r\n";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(245, 582);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // AndroidAppScreenshot
            // 
            this.AndroidAppScreenshot.Image = global::InstallSummaryCA.Properties.Resources.AndroidAppScreeshot;
            this.AndroidAppScreenshot.ImageLocation = "";
            this.AndroidAppScreenshot.Location = new System.Drawing.Point(15, 73);
            this.AndroidAppScreenshot.Name = "AndroidAppScreenshot";
            this.AndroidAppScreenshot.Size = new System.Drawing.Size(251, 403);
            this.AndroidAppScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AndroidAppScreenshot.TabIndex = 1;
            this.AndroidAppScreenshot.TabStop = false;
            // 
            // lbPassword
            // 
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(272, 341);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(259, 23);
            this.lbPassword.TabIndex = 7;
            this.lbPassword.Text = "The password you created in previous step.";
            // 
            // AndroidAppSetup
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 617);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelFinally);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.labelIp);
            this.Controls.Add(this.labelUserID);
            this.Controls.Add(this.AndroidAppScreenshot);
            this.Controls.Add(this.labelExplanation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AndroidAppSetup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeCloud Android Setup";
            this.Load += new System.EventHandler(this.AndroidAppSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AndroidAppScreenshot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelExplanation;
        private System.Windows.Forms.PictureBox AndroidAppScreenshot;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label labelIp;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelFinally;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label lbPassword;
    }
}