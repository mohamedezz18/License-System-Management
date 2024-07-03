using DVLDBussinessLayer;
using DVLDPresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Test
{
    public partial class uclReadTestInfo : UserControl
    {
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
       // int TestAppointmentInfoID;
        public uclReadTestInfo()
        {
            InitializeComponent();
        }

        public bool LoadDataByID(int TestAppointmentInfoId)
        {
            TestAppointmentInfo = clsTestAppointment.GetTestAppointmentByID(TestAppointmentInfoId);
            if (TestAppointmentInfo == null)
            {
                return false;
            }
            _FillData();
            return true;
        }

        private void _FillData()
        {
            lblLicenseAppID.Text = TestAppointmentInfo.LocalDrivingLicenseApplication.LocalDrivingLicenseID.ToString();
            lblLicenseClass.Text = TestAppointmentInfo.LocalDrivingLicenseApplication.LicenseClasses.ClassName.ToString();
            lblPersonName.Text = TestAppointmentInfo.LocalDrivingLicenseApplication.ApplicationInfo.Person.FullName;
            lblTrial.Text = clsTest.GetTrial(TestAppointmentInfo.LocalDrivingLicenseApplication.LocalDrivingLicenseID, (int)_TestType).ToString();
            lblDate.Text = TestAppointmentInfo.AppointmentDate.ToString();
            lblFees.Text = clsTestTypes.FindTestTypeByID((int)_TestType).TypeFees.ToString();
        }
    }
}
