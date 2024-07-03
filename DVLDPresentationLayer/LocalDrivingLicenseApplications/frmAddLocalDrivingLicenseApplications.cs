using DVLDBussinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLDPresentationLayer.LocalDrivingLicenseApplications
{
    public partial class frmAddLocalDrivingLicenseApplications : Form
    {
        int _PersonId = -1;

        int _LocalDrivingLicenseID = -1;
        clsApplcation applcation;
        clsLocalDrivingLicenseApp LocalDrivingLicense;

        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        public frmAddLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddLocalDrivingLicenseApplications(int LocalDrivingLicenseId)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicenseID = LocalDrivingLicenseId;
        }

        private void PersonInfo_Click(object sender, EventArgs e)
        {

        }

        private void _FillComboxLicensClass()
        {
            DataTable LicensClass = clsLicenseClasses.ListOfLicenseClasse();

            foreach (DataRow row in LicensClass.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }

        private void ResetButtons()
        {
            _FillComboxLicensClass();
            cbLicenseClass.SelectedIndex = 0;
            if (_Mode == enMode.AddNew)
            {
                applcation = new clsApplcation();
                applcation.ApplicationTypeID = 1;
                applcation.ApplicationDate = DateTime.Now;
                LocalDrivingLicense = new clsLocalDrivingLicenseApp();

            }
            if (_Mode == enMode.Update)
            {
                LocalDrivingLicense = clsLocalDrivingLicenseApp.FindLocalDrivingLicenseByID(_LocalDrivingLicenseID);
                applcation = clsApplcation.GetApplicationByID(LocalDrivingLicense.ApplicationInfo.ApplicationID);
                lblTitle.Text = "Update Local Driving License Applications";
                lblApplicationID.Text = applcation.ApplicationID.ToString();
                uclPersonDetailsWithFilter.FilterEnable = false;
                return;
            }
            lblCreatedUser.Text = clsGlobalUser.CurrentUser.UserName;
            lblApplicationID.Text = "{?????}";
            lblApplicationFees.Text = clsApplicationTypes.FindApplicationTypeByID(applcation.ApplicationTypeID).ApplicationTypeFees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString();
        }

        private void _LoadDate()
        {
            if (LocalDrivingLicense != null)
            {
                uclPersonDetailsWithFilter.LoadData(LocalDrivingLicense.ApplicationInfo.ApplicantPersonID);
                lblApplicationID.Text = applcation.ApplicationID.ToString();
                lblApplicationDate.Text = applcation.ApplicationDate.ToString();
                lblApplicationFees.Text = applcation.PaidFees.ToString();
                lblCreatedUser.Text = applcation.CurrentUser.UserName;
                cbLicenseClass.Text = LocalDrivingLicense.LicenseClasses.ClassName;
            }
        }

        private void _SaveDataApplication()
        {
            applcation.ApplicantPersonID = _PersonId;

            applcation.ApplicationTypeID = 1;
            applcation.ApplicationStatus = clsApplcation.enApplicationStatus.New;
            applcation.LastStatusDate = DateTime.Now;
            applcation.PaidFees = clsApplicationTypes.FindApplicationTypeByID(applcation.ApplicationTypeID).ApplicationTypeFees;
            applcation.CreatedByUserID = clsGlobalUser.CurrentUser.UserID;



        }

        private void _SaveDataLocalDrivingLicense()
        {
            LocalDrivingLicense.ApplicationID = applcation.ApplicationID;
            LocalDrivingLicense.LicenseClassID = clsLicenseClasses.FindLicenseClasseByName(cbLicenseClass.Text).LicenseClassID;
        }

        private void frmAddLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            ResetButtons();
            if (_Mode == enMode.Update)
            {
                _LoadDate();
            }
        }

        private void uclPersonDetailsWithFilter_GetPersonID(int obj)
        {
            _PersonId = obj;
        }

        bool ValidatePersonBeforeSave()
        {
            int ApplicationIDNow = clsLocalDrivingLicenseApp.isPersonUsedForLicenseClass(_PersonId,
                clsLicenseClasses.FindLicenseClasseByName(cbLicenseClass.Text).LicenseClassID);
            if (ApplicationIDNow == -1)
            {
                return true;
            }

            else
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ApplicationIDNow, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidatePersonBeforeSave() == false)
            {
                return;
            }
            _SaveDataApplication();
            if (applcation.SaveApplication())
            {
                _SaveDataLocalDrivingLicense();
                if (LocalDrivingLicense.SaveLocalDrivingLicense())
                {
                    MessageBox.Show("Data Saved Successfully.", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mode = enMode.Update;
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _ValidateNextTab()
        {
            if (_PersonId != -1 || clsPerson.isPersonExist(_PersonId))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Select A Person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabAddLocalLicense.TabPages["ApplicationInfo"].Enabled = false;
                return false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_ValidateNextTab()) 
            {
                tabAddLocalLicense.SelectedTab = ApplicationInfo;
            }
        }

        private void tabAddLocalLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabAddLocalLicense.SelectedTab == ApplicationInfo)
            {
                if (_ValidateNextTab())
                {
                    tabAddLocalLicense.SelectedTab = ApplicationInfo;
                }
                else
                {
                    tabAddLocalLicense.SelectedTab = PersonInfo;
                }
            }
        }
    }
}
