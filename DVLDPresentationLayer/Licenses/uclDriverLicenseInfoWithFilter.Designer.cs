namespace DVLDPresentationLayer.Licenses_And_Driver
{
    partial class uclDriverLicenseInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uclDriverLicenseInfoWithFilter));
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2ImageButton();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uclDriverLicenseInfo = new DVLDPresentationLayer.Licenses.uclDriverLicenseInfo();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbFilter.Controls.Add(this.btnSearch);
            this.gbFilter.Controls.Add(this.txbSearch);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(1, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(568, 125);
            this.gbFilter.TabIndex = 2;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnSearch
            // 
            this.btnSearch.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnSearch.HoverState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnSearch.ImageRotate = 0F;
            this.btnSearch.ImageSize = new System.Drawing.Size(35, 35);
            this.btnSearch.Location = new System.Drawing.Point(472, 46);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSearch.Size = new System.Drawing.Size(46, 49);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txbSearch
            // 
            this.txbSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSearch.Location = new System.Drawing.Point(172, 51);
            this.txbSearch.Multiline = true;
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(281, 38);
            this.txbSearch.TabIndex = 16;
            this.txbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbSearch_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 31);
            this.label2.TabIndex = 14;
            this.label2.Text = "LicenseID:";
            // 
            // uclDriverLicenseInfo
            // 
            this.uclDriverLicenseInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.uclDriverLicenseInfo.Location = new System.Drawing.Point(1, 134);
            this.uclDriverLicenseInfo.Name = "uclDriverLicenseInfo";
            this.uclDriverLicenseInfo.Size = new System.Drawing.Size(936, 529);
            this.uclDriverLicenseInfo.TabIndex = 0;
            // 
            // uclDriverLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.uclDriverLicenseInfo);
            this.Name = "uclDriverLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(944, 666);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Licenses.uclDriverLicenseInfo uclDriverLicenseInfo;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TextBox txbSearch;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ImageButton btnSearch;
    }
}
