using DVLDBussinessLayer;
using DVLDPresentationLayer.Licenses_And_Driver;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Licenses
{
    public partial class frmRenewlocalDrivingLicense : Form
    {
        int _LicenseID = -1;
        clsLicense RenewLocalDrivingLicense;
        clsApplcation NewApplication;
        public frmRenewlocalDrivingLicense()
        {
            InitializeComponent();
        }

        private void CreateNewApplication()
        {
            if (_LicenseID != -1)
            {
                NewApplication = new clsApplcation();
                NewApplication.ApplicantPersonID = uclDriverLicenseInfoWithFilter.SelectedLicense.Driver.PersonID;
                NewApplication.ApplicationDate = DateTime.Now;
                NewApplication.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.RenewDrivingLicense;
                NewApplication.ApplicationStatus = clsApplcation.enApplicationStatus.New;
                NewApplication.LastStatusDate = DateTime.Now;
                NewApplication.PaidFees = clsApplicationTypes.FindApplicationTypeByID((int)clsApplicationTypes.enApplicationTypes.RenewDrivingLicense).ApplicationTypeFees;
                NewApplication.CreatedByUserID = clsGlobalUser.CurrentUser.UserID;
            }
        }

        void CreateRenewLicense()
        {
            RenewLocalDrivingLicense = new clsLicense();
            RenewLocalDrivingLicense.ApplicationID = NewApplication.ApplicationID;
            RenewLocalDrivingLicense.DriverID = uclDriverLicenseInfoWithFilter.SelectedLicense.DriverID;
            RenewLocalDrivingLicense.LicenseClassID = uclDriverLicenseInfoWithFilter.SelectedLicense.LicenseClassID;
            RenewLocalDrivingLicense.IssueDate = DateTime.Now;
            RenewLocalDrivingLicense.ExpirationDate = RenewLocalDrivingLicense.IssueDate.AddYears(uclDriverLicenseInfoWithFilter.SelectedLicense.LicenseClasse.DefaultValidityLength);
            if (txbNote.Text != null && txbNote.Text != "")
            {
                RenewLocalDrivingLicense.Notes = txbNote.Text;
            }
            else
            {
                RenewLocalDrivingLicense.Notes = null;
            }
            RenewLocalDrivingLicense.PaidFees = uclDriverLicenseInfoWithFilter.SelectedLicense.LicenseClasse.ClassFees;
            RenewLocalDrivingLicense.IssueReason = clsLicense.enIssueReason.Renew;
            RenewLocalDrivingLicense.IsActive = true;
            RenewLocalDrivingLicense.CreatedByUserID = clsGlobalUser.CurrentUser.UserID;
            RenewLocalDrivingLicense.Application = NewApplication;

        }

        private void _FillNewApplicationInfo()
        {
            
            lblRenewLicenseID.Text = "?????";
            lblRLAppID.Text = "?????";
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblAppFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplicationTypes.enApplicationTypes.RenewDrivingLicense).ApplicationTypeFees.ToString();
            lblLicenseFees.Text = uclDriverLicenseInfoWithFilter.SelectedLicense.LicenseClasse.ClassFees.ToString();
            lblOldLicenseID.Text = _LicenseID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(uclDriverLicenseInfoWithFilter.SelectedLicense.LicenseClasse.DefaultValidityLength).ToString();
            lblCreatedUser.Text = clsGlobalUser.CurrentUser.UserName.ToString();
            lblTotalFees.Text = (Convert.ToInt32(lblAppFees.Text) + Convert.ToInt32(lblLicenseFees.Text)).ToString();
        }

        private void _FillLicenseInfo()
        {
            if (uclDriverLicenseInfoWithFilter.SelectedLicense.Application.ApplicationTypeID == (int)clsApplicationTypes.enApplicationTypes.RenewDrivingLicense)
            {
                lblRLAppID.Text = uclDriverLicenseInfoWithFilter.SelectedLicense.ApplicationID.ToString();
            }
            if (RenewLocalDrivingLicense != null && RenewLocalDrivingLicense.LicenseID != -1)
            {
                lblRenewLicenseID.Text = RenewLocalDrivingLicense.LicenseID.ToString();
                lblRLAppID.Text = RenewLocalDrivingLicense.ApplicationID.ToString();
            }
            lblOldLicenseID.Text = _LicenseID.ToString();
            lblApplicationDate.Text = uclDriverLicenseInfoWithFilter.SelectedLicense.Application.ApplicationDate.ToString();
            lblIssueDate.Text = uclDriverLicenseInfoWithFilter.SelectedLicense.IssueDate.ToString();
            lblAppFees.Text = uclDriverLicenseInfoWithFilter.SelectedLicense.Application.PaidFees.ToString();
            lblLicenseFees.Text = uclDriverLicenseInfoWithFilter.SelectedLicense.PaidFees.ToString();
            lblExpirationDate.Text = uclDriverLicenseInfoWithFilter.SelectedLicense.ExpirationDate.ToString();
            lblCreatedUser.Text = uclDriverLicenseInfoWithFilter.SelectedLicense.User.UserName.ToString();
            lblTotalFees.Text = (uclDriverLicenseInfoWithFilter.SelectedLicense.PaidFees + uclDriverLicenseInfoWithFilter.SelectedLicense.Application.PaidFees).ToString();
        }

        private bool _CheckIfLicenseNotExpired()
        {
            if (DateTime.Compare(uclDriverLicenseInfoWithFilter.SelectedLicense.ExpirationDate, DateTime.Now) > 0)
            {
                _FillLicenseInfo();
                uclDriverLicenseInfoWithFilter.SelectedLicense.MakeNotActive();
                return true;
            }
            return false;
        }

        private bool _CheckIfDriverHaveThisLicense()
        {
            int _ID = uclDriverLicenseInfoWithFilter.SelectedLicense.Driver.IsDriverHaveActiveThisLicenseClass(uclDriverLicenseInfoWithFilter.SelectedLicense.LicenseClassID);
            if (_ID != -1)
            {
                MessageBox.Show("This Driver already have this license with ID = " + _ID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _FillLicenseInfo();
                return true;
            }
            return false;
        }
      

        void _HandleLoadData()
        {
            if (_CheckIfDriverHaveThisLicense())
            {
                llLicenseInfo.Enabled = true;
                btnRenew.Enabled = false;
                return;
            }
            if (_CheckIfLicenseNotExpired())
            {
                MessageBox.Show("This license is not expired yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llLicenseInfo.Enabled = true;
                btnRenew.Enabled = false;

                return;
            }
            else
            {
                _FillNewApplicationInfo();
                llLicenseInfo.Enabled = false;
                btnRenew.Enabled = true;
            }
        }

        private void uclDriverLicenseInfoWithFilter_GetLicenseID(int obj)
        {
            _LicenseID = obj;
            _HandleLoadData();
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(uclDriverLicenseInfoWithFilter.SelectedLicense != null)
            {
                frmDriverAllLicense driverAllLicense = new frmDriverAllLicense(uclDriverLicenseInfoWithFilter.SelectedLicense.Driver.PersonID);
                driverAllLicense.ShowDialog();
            }
        }

        private void llLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo licenseInfo = new frmLicenseInfo(_LicenseID);
            licenseInfo.ShowDialog();
        }



        private void btnRenew_Click(object sender, EventArgs e)
        {
            CreateNewApplication();
            if (NewApplication.SaveApplication())
            {
                CreateRenewLicense();
                if (RenewLocalDrivingLicense.SaveLicense())
                {
                    MessageBox.Show("Local Driving License Renewed Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRenew.Enabled = false;
                    NewApplication.Complete();
                    llLicenseInfo.Enabled = true;
                    _LicenseID = RenewLocalDrivingLicense.LicenseID;
                    _FillLicenseInfo();
                }
                else
                {
                    MessageBox.Show("Failed to Renew Local Driving License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}
