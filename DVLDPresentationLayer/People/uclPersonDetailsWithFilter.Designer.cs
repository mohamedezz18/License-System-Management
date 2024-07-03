namespace DVLDPresentationLayer.People
{
    partial class uclPersonDetailsWithFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uclPersonDetailsWithFilter));
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnAddPerson = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnSearch = new Guna.UI2.WinForms.Guna2ImageButton();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uclPersonDetails = new DVLDPresentationLayer.People.uclPersonDetails();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.BackColor = System.Drawing.Color.Silver;
            this.gbFilter.Controls.Add(this.btnAddPerson);
            this.gbFilter.Controls.Add(this.btnSearch);
            this.gbFilter.Controls.Add(this.txbSearch);
            this.gbFilter.Controls.Add(this.cbFilter);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(0, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(940, 125);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnAddPerson.HoverState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAddPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPerson.Image")));
            this.btnAddPerson.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAddPerson.ImageRotate = 0F;
            this.btnAddPerson.ImageSize = new System.Drawing.Size(35, 35);
            this.btnAddPerson.IndicateFocus = true;
            this.btnAddPerson.Location = new System.Drawing.Point(666, 50);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAddPerson.Size = new System.Drawing.Size(46, 49);
            this.btnAddPerson.TabIndex = 18;
            this.btnAddPerson.Visible = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnSearch.HoverState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnSearch.ImageRotate = 0F;
            this.btnSearch.ImageSize = new System.Drawing.Size(35, 35);
            this.btnSearch.Location = new System.Drawing.Point(614, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSearch.Size = new System.Drawing.Size(46, 49);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // txbSearch
            // 
            this.txbSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSearch.Location = new System.Drawing.Point(320, 55);
            this.txbSearch.Multiline = true;
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(281, 38);
            this.txbSearch.TabIndex = 16;
            this.txbSearch.Visible = false;
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
            "PersonID",
            "NationalNO"});
            this.cbFilter.Location = new System.Drawing.Point(123, 54);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(191, 36);
            this.cbFilter.TabIndex = 15;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 31);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filter By:";
            // 
            // uclPersonDetails
            // 
            this.uclPersonDetails.AutoSize = true;
            this.uclPersonDetails.BackColor = System.Drawing.Color.Silver;
            this.uclPersonDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uclPersonDetails.Location = new System.Drawing.Point(0, 134);
            this.uclPersonDetails.Name = "uclPersonDetails";
            this.uclPersonDetails.Size = new System.Drawing.Size(943, 416);
            this.uclPersonDetails.TabIndex = 0;
            // 
            // uclPersonDetailsWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.uclPersonDetails);
            this.Name = "uclPersonDetailsWithFilter";
            this.Size = new System.Drawing.Size(943, 550);
            this.Load += new System.EventHandler(this.uclPersonDetailsWithFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private uclPersonDetails uclPersonDetails;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TextBox txbSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ImageButton btnSearch;
        private Guna.UI2.WinForms.Guna2ImageButton btnAddPerson;
    }
}
