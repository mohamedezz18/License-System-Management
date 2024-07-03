using DVLDBussinessLayer;
using DVLDPresentationLayer.Licenses_And_Driver;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Licenses
{
    public partial class frmRelacementforDamaedLicense : Form
    {
        int _LicenseID = -1;
        clsLicense ReplaceLocalDrivingLicense;
        clsApplcation NewApplication;
        public frmRelacementforDamaedLicense()
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
                if (rbDamaged.Checked)
                {
                    NewApplication.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.ReplacementForDamagedDrivingLicense;
                    NewApplication.PaidFees = clsApplicationTypes.FindApplicationTypeByID((int)clsApplicationTypes.enApplicationTypes.ReplacementForDamagedDrivingLicense).ApplicationTypeFees;

                }
                else if (rbLost.Checked)
                {
                    NewApplication.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.ReplacementForLostDrivingLicense;
                    NewApplication.PaidFees = clsApplicationTypes.FindApplicationTypeByID((int)clsApplicationTypes.enApplicationTypes.ReplacementForLostDrivingLicense).ApplicationTypeFees;
                }
                NewApplication.ApplicationStatus = clsApplcation.enApplicationStatus.New;
                NewApplication.LastStatusDate = DateTime.Now;
                NewApplication.CreatedByUserID = clsGlobalUser.CurrentUser.UserID;
            }

        }

        void CreateReplaceLicense()
        {
            ReplaceLocalDrivingLicense = new clsLicense();
            ReplaceLocalDrivingLicense.ApplicationID = NewApplication.ApplicationID;
            ReplaceLocalDrivingLicense.DriverID = uclDriverLicenseInfoWithFilter.SelectedLicense.DriverID;
            ReplaceLocalDrivingLicense.LicenseClassID = uclDriverLicenseInfoWithFilter.SelectedLicense.LicenseClassID;
            ReplaceLocalDrivingLicense.IssueDate = DateTime.Now;
            ReplaceLocalDrivingLicense.ExpirationDate = ReplaceLocalDrivingLicense.IssueDate.AddYears(uclDriverLicenseInfoWithFilter.SelectedLicense.LicenseClasse.DefaultValidityLength);
            ReplaceLocalDrivingLicense.Notes = null;
            ReplaceLocalDrivingLicense.PaidFees = uclDriverLicenseInfoWithFilter.SelectedLicense.LicenseClasse.ClassFees;
            if (rbDamaged.Checked)
            {
                ReplaceLocalDrivingLicense.IssueReason = clsLicense.enIssueReason.ReplacementForDamaged;
            }
            else if (rbLost.Checked)
            {
                ReplaceLocalDrivingLicense.IssueReason = clsLicense.enIssueReason.ReplacementForLost;
            }
            ReplaceLocalDrivingLicense.IsActive = true;
            ReplaceLocalDrivingLicense.CreatedByUserID = clsGlobalUser.CurrentUser.UserID;
            ReplaceLocalDrivingLicense.Application = NewApplication;

        }

        private void _FillNewApplicationInfo()
        {
            lblReplaceLicenseID.Text = "?????";
            lblRLAppID.Text = "?????";
            lblApplicationDate.Text = DateTime.Now.ToString();
            if (rbDamaged.Checked)
            {
                lblAppFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplicationTypes.enApplicationTypes.ReplacementForDamagedDrivingLicense).ApplicationTypeFees.ToString();

            }
            else if (rbLost.Checked)
            {
                lblAppFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplicationTypes.enApplicationTypes.ReplacementForLostDrivingLicense).ApplicationTypeFees.ToString();
            }
            lblOldLicenseID.Text = _LicenseID.ToString();
            lblCreatedUser.Text = clsGlobalUser.CurrentUser.UserName.ToString();
        }

        private void _FillLicenseInfo()
        {
            if (ReplaceLocalDrivingLicense != null && ReplaceLocalDrivingLicense.LicenseID != -1)
            {
                lblReplaceLicenseID.Text = ReplaceLocalDrivingLicense.LicenseID.ToString();
                lblRLAppID.Text = ReplaceLocalDrivingLicense.ApplicationID.ToString();
            }
            lblOldLicenseID.Text = _LicenseID.ToString();
            lblApplicationDate.Text = uclDriverLicenseInfoWithFilter.SelectedLicense.Application.ApplicationDate.ToString();
            lblAppFees.Text = uclDriverLicenseInfoWithFilter.SelectedLicense.Application.PaidFees.ToString();
            lblCreatedUser.Text = uclDriverLicenseInfoWithFilter.SelectedLicense.User.UserName.ToString();
        }


        private bool _CheckIfLicenseNotActive()
        {
            if (uclDriverLicenseInfoWithFilter.SelectedLicense.IsActive == false)
            {
                _FillLicenseInfo();
                uclDriverLicenseInfoWithFilter.SelectedLicense.MakeNotActive();
                return true;
            }
            return false;
        }

        void _HandleLoadData()
        {
            if (_CheckIfLicenseNotActive())
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llLicenseInfo.Enabled = true;
                btnIssueReplace.Enabled = false;
                return;
            }
            else
            {
                _FillNewApplicationInfo();
                llLicenseInfo.Enabled = false;
                btnIssueReplace.Enabled = true;
            }
        }

        private void uclDriverLicenseInfoWithFilter_GetLicenseID(int obj)
        {
            _LicenseID = obj;
            _HandleLoadData();
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uclDriverLicenseInfoWithFilter.SelectedLicense != null)
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

        private void btnIssueReplace_Click(object sender, EventArgs e)
        {
            CreateNewApplication();
            if (NewApplication.SaveApplication())
            {
                CreateReplaceLicense();
                if (ReplaceLocalDrivingLicense.SaveLicense())
                {
                    MessageBox.Show("Local Driving License Renewed Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uclDriverLicenseInfoWithFilter.SelectedLicense.MakeNotActive();
                    btnIssueReplace.Enabled = false;
                    NewApplication.Complete();
                    llLicenseInfo.Enabled = true;
                    _LicenseID = ReplaceLocalDrivingLicense.LicenseID;
                    _FillLicenseInfo();
                }
                else
                {
                    MessageBox.Show("Failed to Renew Local Driving License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDamaged.Checked)
            {
                lblAppFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplicationTypes.enApplicationTypes.ReplacementForDamagedDrivingLicense).ApplicationTypeFees.ToString();

            }

        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLost.Checked)
            {
                lblAppFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplicationTypes.enApplicationTypes.ReplacementForLostDrivingLicense).ApplicationTypeFees.ToString();

            }
        }
    }
}
