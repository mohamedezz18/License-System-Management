using DVLDBussinessLayer;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Licenses
{
    public partial class frmAddLicense : Form
    {

        int LocalLicenseAppID = -1;

        clsDriver Driver;
        clsLicense License;
        public frmAddLicense(int LocalLicenseAppId)
        {
            InitializeComponent();
            LocalLicenseAppID = LocalLicenseAppId;
        }

        private void _HandleLoadData()
        {
            if (LocalLicenseAppID != -1)
            {
                uclLocalLicenseApplicationInfo.LoadDataById(LocalLicenseAppID);
                return;
            }
            else
            {
                MessageBox.Show("Error Load Data with this ID" + LocalLicenseAppID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void CreateDriver()
        {
            Driver = clsDriver.FindDriverByPersonID(uclLocalLicenseApplicationInfo.LocalDrivingLicenseApplications.ApplicationInfo.ApplicantPersonID);
            if (Driver == null)
            {
                Driver = new clsDriver();
                Driver.PersonID = uclLocalLicenseApplicationInfo.LocalDrivingLicenseApplications.ApplicationInfo.ApplicantPersonID;
                Driver.CreatedByUserID = clsGlobalUser.CurrentUser.UserID;
                Driver.CreatedDate = DateTime.Now;
            }

        }

        private void IssueLicense()
        {

            License = new clsLicense();
            License.DriverID = Driver.DriverID;
            License.ApplicationID = uclLocalLicenseApplicationInfo.LocalDrivingLicenseApplications.ApplicationID;
            License.LicenseClassID = uclLocalLicenseApplicationInfo.LocalDrivingLicenseApplications.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = License.IssueDate.AddYears(clsLicenseClasses.FindLicenseClasseByID(License.LicenseClassID).DefaultValidityLength);
            if (txbNote.Text != null && txbNote.Text != "")
            {
                License.Notes = txbNote.Text;
            }
            else
            {
                License.Notes = null;
            }
            License.PaidFees = clsLicenseClasses.FindLicenseClasseByID(License.LicenseClassID).ClassFees;
            License.IsActive = true;
            License.CreatedByUserID = clsGlobalUser.CurrentUser.UserID;
            License.IssueReason = clsLicense.enIssueReason.FirstTime;

        }

        bool _SaveData()
        {
            CreateDriver();
            switch (Driver.ModeDriver)
            {
                case clsDriver.enModeDriver.AddNew:
                    {
                        if (Driver.SaveDriver())
                        {
                            IssueLicense();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error: Driver Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;

                        }
                    }
                case clsDriver.enModeDriver.Update:
                    {
                        IssueLicense();
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (!_SaveData())
            {
                return;
            }
            if (License.SaveLicense())
            {
                uclLocalLicenseApplicationInfo.LocalDrivingLicenseApplications.ApplicationInfo.Complete();
                MessageBox.Show("License Issued Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmAddLicense_Load(object sender, EventArgs e)
        {
            _HandleLoadData();
        }
    }
}
