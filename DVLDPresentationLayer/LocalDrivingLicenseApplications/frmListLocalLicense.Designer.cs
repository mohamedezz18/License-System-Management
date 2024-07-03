namespace DVLDPresentationLayer.LocalDrivingLicenseApplications
{
    partial class frmListLocalLicense
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListLocalLicense));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.lblRecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvApplicationLocalLicense = new System.Windows.Forms.DataGridView();
            this.cmsTools = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.EditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.SechduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.visionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writtenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.practicalTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.IssueLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNew = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationLocalLicense)).BeginInit();
            this.cmsTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(135)))));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Local Driving License Applications";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(559, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txbSearch
            // 
            this.txbSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSearch.Location = new System.Drawing.Point(326, 347);
            this.txbSearch.Multiline = true;
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(281, 38);
            this.txbSearch.TabIndex = 20;
            this.txbSearch.Visible = false;
            this.txbSearch.TextChanged += new System.EventHandler(this.txbSearch_TextChanged);
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.Color.Black;
            this.lblRecord.Location = new System.Drawing.Point(111, 742);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(103, 25);
            this.lblRecord.TabIndex = 19;
            this.lblRecord.Text = "#Records:  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 739);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 28);
            this.label3.TabIndex = 18;
            this.label3.Text = "#Records:  ";
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(146)))), ((int)(((byte)(248)))));
            this.cbFilter.FocusedColor = System.Drawing.Color.Empty;
            this.cbFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            this.cbFilter.ForeColor = System.Drawing.Color.Black;
            this.cbFilter.ItemHeight = 30;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "L.D.L AppID",
            "National NO",
            "Full Name",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(129, 350);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(191, 36);
            this.cbFilter.TabIndex = 17;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 31);
            this.label2.TabIndex = 16;
            this.label2.Text = "Filter By:";
            // 
            // dgvApplicationLocalLicense
            // 
            this.dgvApplicationLocalLicense.AllowUserToAddRows = false;
            this.dgvApplicationLocalLicense.AllowUserToDeleteRows = false;
            this.dgvApplicationLocalLicense.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(215)))), ((int)(((byte)(237)))));
            this.dgvApplicationLocalLicense.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApplicationLocalLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApplicationLocalLicense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplicationLocalLicense.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(144)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApplicationLocalLicense.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvApplicationLocalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicationLocalLicense.ContextMenuStrip = this.cmsTools;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvApplicationLocalLicense.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvApplicationLocalLicense.EnableHeadersVisualStyles = false;
            this.dgvApplicationLocalLicense.GridColor = System.Drawing.Color.Gray;
            this.dgvApplicationLocalLicense.Location = new System.Drawing.Point(3, 409);
            this.dgvApplicationLocalLicense.Name = "dgvApplicationLocalLicense";
            this.dgvApplicationLocalLicense.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApplicationLocalLicense.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvApplicationLocalLicense.RowHeadersVisible = false;
            this.dgvApplicationLocalLicense.RowHeadersWidth = 51;
            this.dgvApplicationLocalLicense.RowTemplate.Height = 26;
            this.dgvApplicationLocalLicense.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvApplicationLocalLicense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplicationLocalLicense.Size = new System.Drawing.Size(1399, 327);
            this.dgvApplicationLocalLicense.TabIndex = 14;
            // 
            // cmsTools
            // 
            this.cmsTools.BackColor = System.Drawing.Color.Silver;
            this.cmsTools.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsTools.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ApplicationDetails,
            this.toolStripSeparator1,
            this.EditApplication,
            this.DeleteApplication,
            this.toolStripSeparator2,
            this.CancelApplication,
            this.SechduleTest,
            this.toolStripSeparator3,
            this.IssueLicense,
            this.toolStripSeparator4,
            this.ShowLicense});
            this.cmsTools.Name = "cmsTools";
            this.cmsTools.Size = new System.Drawing.Size(336, 266);
            this.cmsTools.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTools_Opening);
            // 
            // ApplicationDetails
            // 
            this.ApplicationDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationDetails.Image = ((System.Drawing.Image)(resources.GetObject("ApplicationDetails.Image")));
            this.ApplicationDetails.ImageTransparentColor = System.Drawing.Color.Silver;
            this.ApplicationDetails.Name = "ApplicationDetails";
            this.ApplicationDetails.Size = new System.Drawing.Size(335, 30);
            this.ApplicationDetails.Text = "Application Details";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(332, 6);
            // 
            // EditApplication
            // 
            this.EditApplication.BackColor = System.Drawing.Color.Silver;
            this.EditApplication.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditApplication.Image = ((System.Drawing.Image)(resources.GetObject("EditApplication.Image")));
            this.EditApplication.ImageTransparentColor = System.Drawing.Color.DarkGray;
            this.EditApplication.Name = "EditApplication";
            this.EditApplication.Size = new System.Drawing.Size(335, 30);
            this.EditApplication.Text = "Edit Application";
            this.EditApplication.Click += new System.EventHandler(this.EditApplication_Click);
            // 
            // DeleteApplication
            // 
            this.DeleteApplication.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteApplication.Image = ((System.Drawing.Image)(resources.GetObject("DeleteApplication.Image")));
            this.DeleteApplication.ImageTransparentColor = System.Drawing.Color.DarkGray;
            this.DeleteApplication.Name = "DeleteApplication";
            this.DeleteApplication.Size = new System.Drawing.Size(335, 30);
            this.DeleteApplication.Text = "Delete Application";
            this.DeleteApplication.Click += new System.EventHandler(this.DeleteApplication_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.Black;
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.Aqua;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(332, 6);
            // 
            // CancelApplication
            // 
            this.CancelApplication.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.CancelApplication.Image = ((System.Drawing.Image)(resources.GetObject("CancelApplication.Image")));
            this.CancelApplication.Name = "CancelApplication";
            this.CancelApplication.Size = new System.Drawing.Size(335, 30);
            this.CancelApplication.Text = "Cancel Application";
            this.CancelApplication.Click += new System.EventHandler(this.CancelApplication_Click);
            // 
            // SechduleTest
            // 
            this.SechduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visionTestToolStripMenuItem,
            this.writtenToolStripMenuItem,
            this.practicalTestToolStripMenuItem});
            this.SechduleTest.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.SechduleTest.Image = ((System.Drawing.Image)(resources.GetObject("SechduleTest.Image")));
            this.SechduleTest.Name = "SechduleTest";
            this.SechduleTest.Size = new System.Drawing.Size(335, 30);
            this.SechduleTest.Text = "Sechdule Test";
            // 
            // visionTestToolStripMenuItem
            // 
            this.visionTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("visionTestToolStripMenuItem.Image")));
            this.visionTestToolStripMenuItem.Name = "visionTestToolStripMenuItem";
            this.visionTestToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.visionTestToolStripMenuItem.Text = "Vision Test";
            this.visionTestToolStripMenuItem.Click += new System.EventHandler(this.visionTestToolStripMenuItem_Click);
            // 
            // writtenToolStripMenuItem
            // 
            this.writtenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("writtenToolStripMenuItem.Image")));
            this.writtenToolStripMenuItem.Name = "writtenToolStripMenuItem";
            this.writtenToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.writtenToolStripMenuItem.Text = "Written Test";
            this.writtenToolStripMenuItem.Click += new System.EventHandler(this.writtenToolStripMenuItem_Click);
            // 
            // practicalTestToolStripMenuItem
            // 
            this.practicalTestToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.driving_test;
            this.practicalTestToolStripMenuItem.Name = "practicalTestToolStripMenuItem";
            this.practicalTestToolStripMenuItem.Size = new System.Drawing.Size(185, 28);
            this.practicalTestToolStripMenuItem.Text = "Street Test";
            this.practicalTestToolStripMenuItem.Click += new System.EventHandler(this.practicalTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(332, 6);
            // 
            // IssueLicense
            // 
            this.IssueLicense.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.IssueLicense.Image = ((System.Drawing.Image)(resources.GetObject("IssueLicense.Image")));
            this.IssueLicense.Name = "IssueLicense";
            this.IssueLicense.Size = new System.Drawing.Size(335, 30);
            this.IssueLicense.Text = "Issue Driving License (First Time)";
            this.IssueLicense.Click += new System.EventHandler(this.IssueLicense_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(332, 6);
            // 
            // ShowLicense
            // 
            this.ShowLicense.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.ShowLicense.Image = ((System.Drawing.Image)(resources.GetObject("ShowLicense.Image")));
            this.ShowLicense.Name = "ShowLicense";
            this.ShowLicense.Size = new System.Drawing.Size(335, 30);
            this.ShowLicense.Text = "Show License";
            this.ShowLicense.Click += new System.EventHandler(this.ShowLicense_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddNew.AutoRoundedCorners = true;
            this.btnAddNew.BorderRadius = 25;
            this.btnAddNew.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNew.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNew.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNew.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNew.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(145)))), ((int)(((byte)(253)))));
            this.btnAddNew.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(145)))), ((int)(((byte)(253)))));
            this.btnAddNew.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(1155, 333);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(232, 53);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "Add New Local License";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.BackColor = System.Drawing.Color.Transparent;
            this.cbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(146)))), ((int)(((byte)(248)))));
            this.cbStatus.FocusedColor = System.Drawing.Color.Empty;
            this.cbStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            this.cbStatus.ForeColor = System.Drawing.Color.Black;
            this.cbStatus.ItemHeight = 30;
            this.cbStatus.Items.AddRange(new object[] {
            "All",
            "Completed",
            "New",
            "Cancelled"});
            this.cbStatus.Location = new System.Drawing.Point(335, 350);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(157, 36);
            this.cbStatus.TabIndex = 21;
            this.cbStatus.Visible = false;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // frmListLocalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1399, 768);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.txbSearch);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvApplicationLocalLicense);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListLocalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmListLocalLicense";
            this.Load += new System.EventHandler(this.frmListLocalLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationLocalLicense)).EndInit();
            this.cmsTools.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txbSearch;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvApplicationLocalLicense;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddNew;
        private Guna.UI2.WinForms.Guna2ComboBox cbStatus;
        private System.Windows.Forms.ContextMenuStrip cmsTools;
        private System.Windows.Forms.ToolStripMenuItem ApplicationDetails;
        private System.Windows.Forms.ToolStripMenuItem EditApplication;
        private System.Windows.Forms.ToolStripMenuItem DeleteApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CancelApplication;
        private System.Windows.Forms.ToolStripMenuItem SechduleTest;
        private System.Windows.Forms.ToolStripMenuItem visionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writtenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem practicalTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IssueLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}