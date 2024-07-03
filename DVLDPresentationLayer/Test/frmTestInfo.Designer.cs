namespace DVLDPresentationLayer.Test
{
    partial class frmTestInfo
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
            this.uclTestInfo = new DVLDPresentationLayer.Test.uclTestInfo();
            this.SuspendLayout();
            // 
            // uclTestInfo
            // 
            this.uclTestInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.uclTestInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclTestInfo.Location = new System.Drawing.Point(0, 0);
            this.uclTestInfo.Name = "uclTestInfo";
            this.uclTestInfo.Size = new System.Drawing.Size(678, 844);
            this.uclTestInfo.TabIndex = 0;
            this.uclTestInfo.TestType = DVLDBussinessLayer.clsTestTypes.enTestType.VisionTest;
            this.uclTestInfo.CheckSavedData += new System.Action<bool>(this.uclTestInfo_CheckSavedData);
            // 
            // frmTestInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 844);
            this.Controls.Add(this.uclTestInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTestInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Test";
            this.Load += new System.EventHandler(this.frmTestInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private uclTestInfo uclTestInfo;
    }
}