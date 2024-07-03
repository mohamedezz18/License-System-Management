namespace DVLDPresentationLayer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPermissionUser = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmsAccountSettings = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblUserName = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnMinmized = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogOut = new Guna.UI2.WinForms.Guna2Button();
            this.btnAccountSettings = new Guna.UI2.WinForms.Guna2Button();
            this.btnPeople = new Guna.UI2.WinForms.Guna2Button();
            this.btnUsers = new Guna.UI2.WinForms.Guna2Button();
            this.btnDrivers = new Guna.UI2.WinForms.Guna2Button();
            this.btnApplications = new Guna.UI2.WinForms.Guna2Button();
            this.PictureProfile = new System.Windows.Forms.PictureBox();
            this.CurrentUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.cmsAccountSettings.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(50, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "DVLD System";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(67)))), ((int)(((byte)(181)))));
            this.panel1.Controls.Add(this.lblPermissionUser);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.PictureProfile);
            this.panel1.Controls.Add(this.guna2Separator1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 831);
            this.panel1.TabIndex = 1;
            // 
            // lblPermissionUser
            // 
            this.lblPermissionUser.AutoSize = true;
            this.lblPermissionUser.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPermissionUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(202)))), ((int)(((byte)(254)))));
            this.lblPermissionUser.Location = new System.Drawing.Point(134, 115);
            this.lblPermissionUser.Name = "lblPermissionUser";
            this.lblPermissionUser.Size = new System.Drawing.Size(61, 23);
            this.lblPermissionUser.TabIndex = 7;
            this.lblPermissionUser.Text = "Admin";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnLogOut);
            this.panel3.Controls.Add(this.btnAccountSettings);
            this.panel3.Controls.Add(this.guna2Separator3);
            this.panel3.Controls.Add(this.guna2Separator2);
            this.panel3.Controls.Add(this.btnPeople);
            this.panel3.Controls.Add(this.btnUsers);
            this.panel3.Controls.Add(this.btnDrivers);
            this.panel3.Controls.Add(this.btnApplications);
            this.panel3.Location = new System.Drawing.Point(0, 209);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(341, 582);
            this.panel3.TabIndex = 5;
            // 
            // cmsAccountSettings
            // 
            this.cmsAccountSettings.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmsAccountSettings.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsAccountSettings.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAccountSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurrentUserInfo,
            this.ChangePassword});
            this.cmsAccountSettings.Name = "cmsAccountSettings";
            this.cmsAccountSettings.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cmsAccountSettings.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmsAccountSettings.RenderStyle.ColorTable = null;
            this.cmsAccountSettings.RenderStyle.RoundedEdges = true;
            this.cmsAccountSettings.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.cmsAccountSettings.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmsAccountSettings.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsAccountSettings.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.cmsAccountSettings.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmsAccountSettings.Size = new System.Drawing.Size(279, 76);
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator3.FillColor = System.Drawing.Color.Gray;
            this.guna2Separator3.FillStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Separator3.FillThickness = 2;
            this.guna2Separator3.Location = new System.Drawing.Point(3, 370);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(335, 23);
            this.guna2Separator3.TabIndex = 8;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator2.FillColor = System.Drawing.Color.DimGray;
            this.guna2Separator2.FillStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Separator2.FillThickness = 2;
            this.guna2Separator2.Location = new System.Drawing.Point(3, -20);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(141, 23);
            this.guna2Separator2.TabIndex = 8;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUserName.Location = new System.Drawing.Point(132, 67);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(148, 30);
            this.lblUserName.TabIndex = 6;
            this.lblUserName.Text = "Mohamed Ezz";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator1.FillColor = System.Drawing.Color.Gray;
            this.guna2Separator1.FillStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Separator1.FillThickness = 2;
            this.guna2Separator1.Location = new System.Drawing.Point(3, 187);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(335, 23);
            this.guna2Separator1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.btnMinmized);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(341, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1399, 63);
            this.panel2.TabIndex = 5;
            // 
            // PanelMain
            // 
            this.PanelMain.AutoScroll = true;
            this.PanelMain.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(341, 63);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(1399, 768);
            this.PanelMain.TabIndex = 6;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 70;
            this.bunifuElipse1.TargetControl = this.PanelMain;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 25;
            this.bunifuElipse2.TargetControl = this;
            // 
            // btnMinmized
            // 
            this.btnMinmized.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinmized.BackColor = System.Drawing.Color.Transparent;
            this.btnMinmized.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnMinmized.HoverState.ImageSize = new System.Drawing.Size(46, 46);
            this.btnMinmized.Image = ((System.Drawing.Image)(resources.GetObject("btnMinmized.Image")));
            this.btnMinmized.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnMinmized.ImageRotate = 0F;
            this.btnMinmized.ImageSize = new System.Drawing.Size(33, 30);
            this.btnMinmized.Location = new System.Drawing.Point(1296, 18);
            this.btnMinmized.Name = "btnMinmized";
            this.btnMinmized.PressedState.ImageSize = new System.Drawing.Size(46, 46);
            this.btnMinmized.Size = new System.Drawing.Size(33, 36);
            this.btnMinmized.TabIndex = 4;
            this.btnMinmized.UseTransparentBackground = true;
            this.btnMinmized.Click += new System.EventHandler(this.btnMinmized_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnClose.HoverState.ImageSize = new System.Drawing.Size(46, 46);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnClose.ImageRotate = 0F;
            this.btnClose.ImageSize = new System.Drawing.Size(33, 30);
            this.btnClose.Location = new System.Drawing.Point(1343, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedState.ImageSize = new System.Drawing.Size(46, 46);
            this.btnClose.Size = new System.Drawing.Size(33, 36);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogOut.FillColor = System.Drawing.Color.Transparent;
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogOut.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogOut.ImageSize = new System.Drawing.Size(35, 35);
            this.btnLogOut.Location = new System.Drawing.Point(38, 475);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(300, 79);
            this.btnLogOut.TabIndex = 14;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogOut.TextOffset = new System.Drawing.Point(5, 0);
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnAccountSettings
            // 
            this.btnAccountSettings.ContextMenuStrip = this.cmsAccountSettings;
            this.btnAccountSettings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAccountSettings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAccountSettings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAccountSettings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAccountSettings.FillColor = System.Drawing.Color.Transparent;
            this.btnAccountSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnAccountSettings.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAccountSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnAccountSettings.Image")));
            this.btnAccountSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAccountSettings.ImageSize = new System.Drawing.Size(35, 35);
            this.btnAccountSettings.Location = new System.Drawing.Point(38, 390);
            this.btnAccountSettings.Name = "btnAccountSettings";
            this.btnAccountSettings.Size = new System.Drawing.Size(300, 79);
            this.btnAccountSettings.TabIndex = 13;
            this.btnAccountSettings.Text = "Account Settings";
            this.btnAccountSettings.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAccountSettings.TextOffset = new System.Drawing.Point(5, 0);
            this.btnAccountSettings.Click += new System.EventHandler(this.btnAccountSettings_Click_1);
            // 
            // btnPeople
            // 
            this.btnPeople.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPeople.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPeople.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPeople.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPeople.FillColor = System.Drawing.Color.Transparent;
            this.btnPeople.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnPeople.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPeople.Image = ((System.Drawing.Image)(resources.GetObject("btnPeople.Image")));
            this.btnPeople.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPeople.ImageSize = new System.Drawing.Size(35, 35);
            this.btnPeople.Location = new System.Drawing.Point(38, 94);
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.Size = new System.Drawing.Size(300, 79);
            this.btnPeople.TabIndex = 12;
            this.btnPeople.Text = "People";
            this.btnPeople.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPeople.TextOffset = new System.Drawing.Point(5, 0);
            this.btnPeople.Click += new System.EventHandler(this.btnPeople_Click);
            this.btnPeople.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_MouseClick);
            // 
            // btnUsers
            // 
            this.btnUsers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUsers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUsers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUsers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUsers.FillColor = System.Drawing.Color.Transparent;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnUsers.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnUsers.Image")));
            this.btnUsers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUsers.ImageSize = new System.Drawing.Size(35, 35);
            this.btnUsers.Location = new System.Drawing.Point(38, 179);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(300, 79);
            this.btnUsers.TabIndex = 11;
            this.btnUsers.Text = "Users";
            this.btnUsers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUsers.TextOffset = new System.Drawing.Point(5, 0);
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            this.btnUsers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_MouseClick);
            // 
            // btnDrivers
            // 
            this.btnDrivers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDrivers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDrivers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDrivers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDrivers.FillColor = System.Drawing.Color.Transparent;
            this.btnDrivers.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnDrivers.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDrivers.Image = ((System.Drawing.Image)(resources.GetObject("btnDrivers.Image")));
            this.btnDrivers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDrivers.ImageSize = new System.Drawing.Size(35, 35);
            this.btnDrivers.Location = new System.Drawing.Point(38, 264);
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.Size = new System.Drawing.Size(300, 79);
            this.btnDrivers.TabIndex = 10;
            this.btnDrivers.Text = "Drivers";
            this.btnDrivers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDrivers.TextOffset = new System.Drawing.Point(5, 0);
            this.btnDrivers.Click += new System.EventHandler(this.btnDrivers_Click);
            this.btnDrivers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_MouseClick);
            // 
            // btnApplications
            // 
            this.btnApplications.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnApplications.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnApplications.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnApplications.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnApplications.FillColor = System.Drawing.Color.Transparent;
            this.btnApplications.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnApplications.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnApplications.Image = ((System.Drawing.Image)(resources.GetObject("btnApplications.Image")));
            this.btnApplications.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnApplications.ImageSize = new System.Drawing.Size(35, 35);
            this.btnApplications.Location = new System.Drawing.Point(38, 9);
            this.btnApplications.Name = "btnApplications";
            this.btnApplications.Size = new System.Drawing.Size(300, 79);
            this.btnApplications.TabIndex = 9;
            this.btnApplications.Text = "Applications";
            this.btnApplications.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnApplications.TextOffset = new System.Drawing.Point(5, 0);
            this.btnApplications.Click += new System.EventHandler(this.btnApplications_Click);
            this.btnApplications.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_MouseClick);
            // 
            // PictureProfile
            // 
            this.PictureProfile.Location = new System.Drawing.Point(12, 47);
            this.PictureProfile.Name = "PictureProfile";
            this.PictureProfile.Size = new System.Drawing.Size(114, 111);
            this.PictureProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureProfile.TabIndex = 6;
            this.PictureProfile.TabStop = false;
            // 
            // CurrentUserInfo
            // 
            this.CurrentUserInfo.BackColor = System.Drawing.Color.DarkGray;
            this.CurrentUserInfo.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentUserInfo.Image = ((System.Drawing.Image)(resources.GetObject("CurrentUserInfo.Image")));
            this.CurrentUserInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CurrentUserInfo.Name = "CurrentUserInfo";
            this.CurrentUserInfo.Size = new System.Drawing.Size(278, 36);
            this.CurrentUserInfo.Text = "Current User Info";
            this.CurrentUserInfo.Click += new System.EventHandler(this.CurrentUserInfo_Click);
            // 
            // ChangePassword
            // 
            this.ChangePassword.BackColor = System.Drawing.Color.Silver;
            this.ChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("ChangePassword.Image")));
            this.ChangePassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangePassword.Name = "ChangePassword";
            this.ChangePassword.Size = new System.Drawing.Size(278, 36);
            this.ChangePassword.Text = "Change Password";
            this.ChangePassword.Click += new System.EventHandler(this.ChangePassword_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1740, 831);
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.cmsAccountSettings.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProfile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.PictureBox PictureProfile;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPermissionUser;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button btnApplications;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Button btnPeople;
        private Guna.UI2.WinForms.Guna2Button btnUsers;
        private Guna.UI2.WinForms.Guna2Button btnDrivers;
        private Guna.UI2.WinForms.Guna2Button btnLogOut;
        private Guna.UI2.WinForms.Guna2Button btnAccountSettings;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
        private Guna.UI2.WinForms.Guna2ImageButton btnMinmized;
        private System.Windows.Forms.ToolStripMenuItem CurrentUserInfo;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsAccountSettings;
        private System.Windows.Forms.ToolStripMenuItem ChangePassword;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        public System.Windows.Forms.Panel PanelMain;
    }
}

