using DVLDBussinessLayer;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Licenses_And_Driver
{
    public partial class frmAddInternationalLicense : Form
    {
        int _LicenseID = -1;
        clsApplcation NewApplication;
        clsInternationalInternationalLicense InternationalLicense;
        public frmAddInternationalLicense()
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
                NewApplication.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.NewInternationalLicense;
                NewApplication.ApplicationStatus = clsApplcation.enApplicationStatus.New;
                NewApplication.LastStatusDate = DateTime.Now;
                NewApplication.PaidFees = clsApplicationTypes.FindApplicationTypeByID((int)clsApplicationTypes.enApplicationTypes.NewInternationalLicense).ApplicationTypeFees;
                NewApplication.CreatedByUserID = clsGlobalUser.CurrentUser.UserID;
            }
        }

        void CreateInternationalLicense()
        {
            InternationalLicense = new clsInternationalInternationalLicense();
            InternationalLicense.ApplicationID = NewApplication.ApplicationID;
            InternationalLicense.DriverID = uclDriverLicenseInfoWithFilter.SelectedLicense.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = _LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.CreatedByUserID = clsGlobalUser.CurrentUser.UserID;
            InternationalLicense.IsActive = true;
            InternationalLicense.Application = NewApplication;
        }

        private void _FillNewApplicationInfo()
        {
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplicationTypes.enApplicationTypes.NewInternationalLicense).ApplicationTypeFees.ToString();
            lblLocalLicenseID.Text = _LicenseID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString();
            lblCreatedUser.Text = clsGlobalUser.CurrentUser.UserName.ToString();
        }

        private void _FillInternationalApplicationInfo()
        {
            lblILAppID.Text = InternationalLicense.InternationalLicenseID.ToString();
            lblApplicationDate.Text = InternationalLicense.Application.ApplicationDate.ToString();
            lblIssueDate.Text = InternationalLicense.IssueDate.ToString();
            lblFees.Text = InternationalLicense.Application.PaidFees.ToString();
            lblLocalLicenseID.Text = InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblExpirationDate.Text = InternationalLicense.ExpirationDate.ToString();
            lblCreatedUser.Text = InternationalLicense.CreatedByUserID.ToString();
        }

        private bool _LoadInternationalLicenseIfExist()
        {
            int IntLicenseID = clsInternationalInternationalLicense.CheckInternationalLicenseByLocalID(_LicenseID);
            if (IntLicenseID != -1)
            {
                InternationalLicense = clsInternationalInternationalLicense.FindInternationalLicenseByID(IntLicenseID);
                _FillInternationalApplicationInfo();
                return true;
            }
            return false;
        }

        void _HandleLoadData()
        {
            if (_LoadInternationalLicenseIfExist())
            {

                btnIssue.Enabled = false;
                llLicenseInfo.Enabled = true;
                MessageBox.Show("Person already have an active international license with ID =" + InternationalLicense.InternationalLicenseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_LicenseID != -1)
            {
                _FillNewApplicationInfo();
                llLicenseInfo.Enabled = true;
                btnIssue.Enabled = true;
            }
            else
            {
                btnIssue.Enabled = false;
                llLicenseInfo.Enabled = false;
            }
        }

        private void uclDriverLicenseInfoWithFilter_GetLicenseID(int obj)
        {
            _LicenseID = obj;
            _HandleLoadData();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            CreateNewApplication();
            if (NewApplication.SaveApplication())
            {
                CreateInternationalLicense();
                if (InternationalLicense.SaveInternationalLicense() && uclDriverLicenseInfoWithFilter.SelectedLicense.IsActive == true)
                {
                    MessageBox.Show("International License Issued Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnIssue.Enabled = false;
                    NewApplication.Complete();
                    llLicenseInfo.Enabled = true;
                    _FillInternationalApplicationInfo();

                }
                else
                {
                    MessageBox.Show("Failed to issue International License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void llLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverInternationalInfo driverInternationalInfo = new frmDriverInternationalInfo(InternationalLicense.InternationalLicenseID);
            driverInternationalInfo.ShowDialog();

        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uclDriverLicenseInfoWithFilter.SelectedLicense != null)
            {
                frmDriverAllLicense driverAllLicense = new frmDriverAllLicense(uclDriverLicenseInfoWithFilter.SelectedLicense.Driver.PersonID);
                driverAllLicense.ShowDialog();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
