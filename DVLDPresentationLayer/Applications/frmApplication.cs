using DVLDPresentationLayer.Licenses;
using DVLDPresentationLayer.Licenses_And_Driver;
using DVLDPresentationLayer.LocalDrivingLicenseApplications;
using DVLDPresentationLayer.People;
using DVLDPresentationLayer.Users;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Applications
{
    public partial class frmApplication : Form
    {

        frmMain Main = null;

        public frmApplication(frmMain main)
        {
            InitializeComponent();
            Main = main;
        }

        void _MakeElipse(Guna2CustomGradientPanel NewPanel)
        {
            bunifuElipse.ApplyElipse(NewPanel);
            
        }

        public void OpenPanel(Guna2CustomGradientPanel CurrentPanel, Guna2CustomGradientPanel NewPanel)
        {
            if (this.pnlMain.Controls.Count > 0)
            {
                this.pnlMain.Controls.RemoveAt(0);
                CurrentPanel.Visible = false;
                
            }          
            NewPanel.Visible = true;
            NewPanel.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(NewPanel);
            this.pnlMain.Tag = NewPanel;
            bunifuElipse.ApplyElipse(NewPanel);
        }


        private void btnApplicationTypes_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes manageApplicationTypes = new frmManageApplicationTypes();
            manageApplicationTypes.ShowDialog();
        }

        private void btnTestTypes_Click(object sender, EventArgs e)
        {
            frmManageTestTypes testTypes = new frmManageTestTypes();
            testTypes.ShowDialog();
        }

        private void btnDrivingLicensesServices_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlApplications, pnlLicensesServices);
        }

        private void btnBackToFormApplications_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlLicensesServices, pnlApplications);
        }

        private void btnNewDrivingLicenses_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlLicensesServices, pnlNewLicense);
        }

        private void btnBackToLicensesServices_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlNewLicense, pnlLicensesServices);

        }

        private void btnLocalLicense_Click(object sender, EventArgs e)
        {
            frmAddLocalDrivingLicenseApplications addLocalDrivingLicenseApplications = new frmAddLocalDrivingLicenseApplications();
            addLocalDrivingLicenseApplications.ShowDialog();
        }
  
        private void btnManageApplications_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlLicensesServices, pnlManageApplications);
        }
        
        private void btnBackToLicensesServices2_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlManageApplications, pnlLicensesServices);
        }

        private void btnLocalLicenseApplications_Click(object sender, EventArgs e)
        {
            Main.OpenForm(new frmListLocalLicense());
        }

        private void btnInternationalLicense_Click(object sender, EventArgs e)
        {
            frmAddInternationalLicense addInternationalLicense = new frmAddInternationalLicense();
            addInternationalLicense.ShowDialog();
        }

        private void btnRenewDrivingLicenses_Click(object sender, EventArgs e)
        {
            frmRenewlocalDrivingLicense renewLocalDrivingLicense = new frmRenewlocalDrivingLicense();
            renewLocalDrivingLicense.ShowDialog();
        }

        private void btnReplacementForDamaged_Click(object sender, EventArgs e)
        {
            frmRelacementforDamaedLicense ReplacementforDamaedLicense = new frmRelacementforDamaedLicense();
            ReplacementforDamaedLicense.ShowDialog();
        }
    }
}
