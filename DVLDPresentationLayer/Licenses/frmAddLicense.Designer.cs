namespace DVLDPresentationLayer.Licenses
{
    partial class frmAddLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddLicense));
            this.btnIssue = new Guna.UI2.WinForms.Guna2Button();
            this.txbNote = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uclLocalLicenseApplicationInfo = new DVLDPresentationLayer.LocalDrivingLicenseApplications.uclLocalLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIssue
            // 
            this.btnIssue.AutoRoundedCorners = true;
            this.btnIssue.BorderRadius = 21;
            this.btnIssue.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIssue.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIssue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIssue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIssue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(67)))), ((int)(((byte)(181)))));
            this.btnIssue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnIssue.Location = new System.Drawing.Point(344, 765);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(160, 45);
            this.btnIssue.TabIndex = 94;
            this.btnIssue.Text = "Issue";
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // txbNote
            // 
            this.txbNote.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txbNote.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNote.Location = new System.Drawing.Point(216, 649);
            this.txbNote.Multiline = true;
            this.txbNote.Name = "txbNote";
            this.txbNote.Size = new System.Drawing.Size(470, 92);
            this.txbNote.TabIndex = 93;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(134, 657);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 92;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(36, 657);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 35);
            this.label1.TabIndex = 91;
            this.label1.Text = "Note:";
            // 
            // uclLocalLicenseApplicationInfo
            // 
            this.uclLocalLicenseApplicationInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.uclLocalLicenseApplicationInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.uclLocalLicenseApplicationInfo.Location = new System.Drawing.Point(0, 0);
            this.uclLocalLicenseApplicationInfo.Name = "uclLocalLicenseApplicationInfo";
            this.uclLocalLicenseApplicationInfo.Size = new System.Drawing.Size(938, 631);
            this.uclLocalLicenseApplicationInfo.TabIndex = 0;
            // 
            // frmAddLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(938, 836);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.txbNote);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uclLocalLicenseApplicationInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add License";
            this.Load += new System.EventHandler(this.frmAddLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LocalDrivingLicenseApplications.uclLocalLicenseApplicationInfo uclLocalLicenseApplicationInfo;
        private Guna.UI2.WinForms.Guna2Button btnIssue;
        private System.Windows.Forms.TextBox txbNote;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}