namespace DVLDPresentationLayer.Licenses_And_Driver
{
    partial class frmDriverAllLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDriverAllLicense));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Local = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocal = new System.Windows.Forms.DataGridView();
            this.cmsToolLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowLicenseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.International = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvInternational = new System.Windows.Forms.DataGridView();
            this.uclPersonDetailsWithFilter1 = new DVLDPresentationLayer.People.uclPersonDetailsWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.Local.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).BeginInit();
            this.cmsToolLocal.SuspendLayout();
            this.International.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternational)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(470, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "License History";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(322, 430);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Local);
            this.tabControl.Controls.Add(this.International);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 618);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1277, 256);
            this.tabControl.TabIndex = 3;
            // 
            // Local
            // 
            this.Local.BackColor = System.Drawing.Color.Gainsboro;
            this.Local.Controls.Add(this.label2);
            this.Local.Controls.Add(this.dgvLocal);
            this.Local.Location = new System.Drawing.Point(4, 34);
            this.Local.Name = "Local";
            this.Local.Padding = new System.Windows.Forms.Padding(3);
            this.Local.Size = new System.Drawing.Size(1269, 218);
            this.Local.TabIndex = 0;
            this.Local.Text = "Local";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "local License History:";
            // 
            // dgvLocal
            // 
            this.dgvLocal.AllowDrop = true;
            this.dgvLocal.AllowUserToAddRows = false;
            this.dgvLocal.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(215)))), ((int)(((byte)(237)))));
            this.dgvLocal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvLocal.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(144)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocal.ContextMenuStrip = this.cmsToolLocal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocal.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLocal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvLocal.EnableHeadersVisualStyles = false;
            this.dgvLocal.GridColor = System.Drawing.Color.Gray;
            this.dgvLocal.Location = new System.Drawing.Point(3, 39);
            this.dgvLocal.Name = "dgvLocal";
            this.dgvLocal.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocal.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLocal.RowHeadersVisible = false;
            this.dgvLocal.RowHeadersWidth = 51;
            this.dgvLocal.RowTemplate.Height = 26;
            this.dgvLocal.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvLocal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocal.Size = new System.Drawing.Size(1263, 176);
            this.dgvLocal.TabIndex = 5;
            // 
            // cmsToolLocal
            // 
            this.cmsToolLocal.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.cmsToolLocal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsToolLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowLicenseInfo});
            this.cmsToolLocal.Name = "cmsToolLocal";
            this.cmsToolLocal.Size = new System.Drawing.Size(223, 32);
            // 
            // ShowLicenseInfo
            // 
            this.ShowLicenseInfo.Image = ((System.Drawing.Image)(resources.GetObject("ShowLicenseInfo.Image")));
            this.ShowLicenseInfo.Name = "ShowLicenseInfo";
            this.ShowLicenseInfo.Size = new System.Drawing.Size(222, 28);
            this.ShowLicenseInfo.Text = "Show License Info";
            this.ShowLicenseInfo.Click += new System.EventHandler(this.ShowLicenseInfo_Click);
            // 
            // International
            // 
            this.International.Controls.Add(this.label3);
            this.International.Controls.Add(this.dgvInternational);
            this.International.Location = new System.Drawing.Point(4, 34);
            this.International.Name = "International";
            this.International.Padding = new System.Windows.Forms.Padding(3);
            this.International.Size = new System.Drawing.Size(1269, 218);
            this.International.TabIndex = 1;
            this.International.Text = "International";
            this.International.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(303, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "International License History:";
            // 
            // dgvInternational
            // 
            this.dgvInternational.AllowUserToAddRows = false;
            this.dgvInternational.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(215)))), ((int)(((byte)(237)))));
            this.dgvInternational.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInternational.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternational.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(144)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternational.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInternational.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternational.ContextMenuStrip = this.cmsToolLocal;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternational.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvInternational.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvInternational.EnableHeadersVisualStyles = false;
            this.dgvInternational.GridColor = System.Drawing.Color.Gray;
            this.dgvInternational.Location = new System.Drawing.Point(3, 39);
            this.dgvInternational.Name = "dgvInternational";
            this.dgvInternational.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternational.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvInternational.RowHeadersVisible = false;
            this.dgvInternational.RowHeadersWidth = 51;
            this.dgvInternational.RowTemplate.Height = 26;
            this.dgvInternational.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvInternational.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternational.Size = new System.Drawing.Size(1263, 176);
            this.dgvInternational.TabIndex = 6;
            // 
            // uclPersonDetailsWithFilter1
            // 
            this.uclPersonDetailsWithFilter1.BackColor = System.Drawing.Color.Silver;
            this.uclPersonDetailsWithFilter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uclPersonDetailsWithFilter1.FilterEnable = false;
            this.uclPersonDetailsWithFilter1.Location = new System.Drawing.Point(340, 72);
            this.uclPersonDetailsWithFilter1.Name = "uclPersonDetailsWithFilter1";
            this.uclPersonDetailsWithFilter1.Size = new System.Drawing.Size(937, 540);
            this.uclPersonDetailsWithFilter1.TabIndex = 4;
            // 
            // frmDriverAllLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1277, 874);
            this.Controls.Add(this.uclPersonDetailsWithFilter1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDriverAllLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License History";
            this.Load += new System.EventHandler(this.frmDriverAllLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.Local.ResumeLayout(false);
            this.Local.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).EndInit();
            this.cmsToolLocal.ResumeLayout(false);
            this.International.ResumeLayout(false);
            this.International.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternational)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Local;
        private System.Windows.Forms.TabPage International;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLocal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvInternational;
        private People.uclPersonDetailsWithFilter uclPersonDetailsWithFilter1;
        private System.Windows.Forms.ContextMenuStrip cmsToolLocal;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseInfo;
    }
}