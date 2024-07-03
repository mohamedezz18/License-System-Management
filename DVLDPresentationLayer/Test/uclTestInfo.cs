using DVLDBussinessLayer;
using DVLDPresentationLayer.Properties;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Test
{
    public partial class uclTestInfo : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<bool> CheckSavedData;
        // Create a protected method to raise the event with a parameter
        protected virtual void CheckSave(bool Result)
        {
            Action<bool> handler = CheckSavedData;
            if (handler != null)
            {
                handler(Result); // Raise the event with the parameter
            }
        }

        private enum TestAttend { RetakeTest = 0, FirstTime = 1 }
        private TestAttend _TestAttend = TestAttend.FirstTime;

        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private clsTestTypes.enTestType _TestType;
        public clsTestTypes.enTestType TestType
        {
            get { return _TestType; }
            set
            {
                _TestType = value;
                switch (_TestType)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        {
                            //lblAdress.Text = "Vision Test";
                            gbTestType.Text = "Vision Test";
                            pbIcon.Image = Resources.examine;
                            break;
                        }
                    case clsTestTypes.enTestType.WriteTest:
                        {
                            // lblAdress.Text = "Write Test";
                            gbTestType.Text = "Write Test";
                            pbIcon.Image = Resources.online_test__1_;
                            break;
                        }
                    case clsTestTypes.enTestType.StreetTest:
                        {
                            //lblAdress.Text = "Street Test";
                            gbTestType.Text = "Street Test";
                            pbIcon.Image = Resources.driving_test;
                            break;
                        }

                }
            }
        }

        clsTestAppointment TestAppointmentInfo;

        clsLocalDrivingLicenseApp LocalDrivingLicense;


        public uclTestInfo()
        {
            InitializeComponent();
        }

        private void HandleEditTest()
        {
            if (TestAppointmentInfo.IsLocked == true)
            {
                lblError.Visible = true;
                gbReTakeTest.Enabled = false;
                gbTestType.Enabled = false;
                btnSave.Enabled = false;
            }
        }
        private void HandleDatePicker()
        {
            if (_Mode == enMode.Update)
            {
                if (DateTime.Compare(DateTime.Now, TestAppointmentInfo.AppointmentDate) < 0)
                    dateTimePicker.MinDate = DateTime.Now;
                else
                    dateTimePicker.MinDate = TestAppointmentInfo.AppointmentDate;
            }
            else
            {
                dateTimePicker.MinDate = DateTime.Now;
            }
        }

        public void LoadInfo(int LocalDrivingLicenseApplicationId, int TestAppointmentID = -1)
        {
            LocalDrivingLicense = clsLocalDrivingLicenseApp.FindLocalDrivingLicenseByID(LocalDrivingLicenseApplicationId);
            if (LocalDrivingLicense == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID =" + LocalDrivingLicenseApplicationId, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (TestAppointmentID == -1)
            {
                _Mode = enMode.AddNew;
                TestAppointmentInfo = new clsTestAppointment();
            }
            else if (TestAppointmentID != -1)
            {
                _Mode = enMode.Update;
                TestAppointmentInfo = clsTestAppointment.GetTestAppointmentByID(TestAppointmentID);
                HandleEditTest();
            }

            if (LocalDrivingLicense.HasAttendedSimilarTestBefore((int)_TestType))
            {
                _TestAttend = TestAttend.RetakeTest;
                gbReTakeTest.Enabled = true;
            }
            else
            {
                _TestAttend = TestAttend.FirstTime;
                gbReTakeTest.Enabled = false;

            }
            _FillTestAppointmentInfo();

        }

        void _FillTestAppointmentInfo()
        {
            if (TestAppointmentInfo != null)
            {
                lblLicenseAppID.Text = LocalDrivingLicense.LocalDrivingLicenseID.ToString();
                lblLicenseClass.Text = LocalDrivingLicense.LicenseClasses.ClassName.ToString();
                lblPersonName.Text = LocalDrivingLicense.ApplicationInfo.Person.FullName;
                lblTrial.Text = clsTest.GetTrial(LocalDrivingLicense.LocalDrivingLicenseID, (int)_TestType).ToString();
                HandleDatePicker();
                lblFees.Text = clsTestTypes.FindTestTypeByID((int)_TestType).TypeFees.ToString();
                if (_TestAttend == TestAttend.RetakeTest && TestAppointmentInfo.RetakeTestApplicationID != -1)
                {
                    lblRAppFees.Text = clsApplicationTypes.FindApplicationTypeByID((int)clsApplicationTypes.enApplicationTypes.RetakeTest).ApplicationTypeFees.ToString();
                    lblTotalFees.Text = ((clsApplicationTypes.FindApplicationTypeByID((int)clsApplicationTypes.enApplicationTypes.RetakeTest).ApplicationTypeFees)
                        + clsTestTypes.FindTestTypeByID((int)_TestType).TypeFees).ToString();
                    lblReTakeID.Text = TestAppointmentInfo.RetakeTestApplicationID.ToString();
                }
            }
        }

        private bool _handleRetakeTest()
        {
            if (_TestAttend == TestAttend.RetakeTest && _Mode == enMode.AddNew)
            {
                clsApplcation RetakeApplication = new clsApplcation();
                RetakeApplication.ApplicantPersonID = LocalDrivingLicense.ApplicationInfo.Person.PersonID;
                RetakeApplication.ApplicationDate = DateTime.Now;
                RetakeApplication.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.RetakeTest;
                RetakeApplication.LastStatusDate = DateTime.Now;
                RetakeApplication.PaidFees = clsApplicationTypes.FindApplicationTypeByID((int)clsApplicationTypes.enApplicationTypes.RetakeTest).ApplicationTypeFees;
                RetakeApplication.CreatedByUserID = clsGlobalUser.CurrentUser.UserID;
                RetakeApplication.ApplicationStatus = clsApplcation.enApplicationStatus.New;
                if (!RetakeApplication.SaveApplication())
                {
                    TestAppointmentInfo.RetakeTestApplicationID = -1;
                    MessageBox.Show("Error: Failed to save Retake Test Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                TestAppointmentInfo.RetakeTestApplicationID = RetakeApplication.ApplicationID;

            }
            else
            {
                TestAppointmentInfo.RetakeTestApplicationID = -1;
                return true;
            }
            return true;
        }

        private void _Save()
        {
            TestAppointmentInfo.TestTypeID = (int)_TestType;
            TestAppointmentInfo.LocalDrivingLicenseApplicationID = LocalDrivingLicense.LocalDrivingLicenseID;
            TestAppointmentInfo.AppointmentDate = dateTimePicker.Value;
            TestAppointmentInfo.PaidFees = clsTestTypes.FindTestTypeByID((int)_TestType).TypeFees;
            TestAppointmentInfo.UserID = clsGlobalUser.CurrentUser.UserID;
            TestAppointmentInfo.IsLocked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_handleRetakeTest())
            {
                return;
            }
            _Save();
            if (TestAppointmentInfo.SaveTestAppointment())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Test Appointment Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (CheckSavedData != null)
                {
                    CheckSave(true);
                }
            }
            else
            {

                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
