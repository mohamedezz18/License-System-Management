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
    public partial class frmTestAppointments : Form
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
                            lblAdress.Text = "Vision Test";
                            pbIcon.Image = Resources.examine;
                            break;
                        }
                    case clsTestTypes.enTestType.WriteTest:
                        {
                            lblAdress.Text = "Write Test";
                            pbIcon.Image = Resources.online_test__1_;
                            break;
                        }
                    case clsTestTypes.enTestType.StreetTest:
                        {
                            lblAdress.Text = "Street Test";
                            pbIcon.Image = Resources.driving_test;
                            break;
                        }

                }
            }
        }

        int LocalDrivingLicenseApplicationID = -1;
        clsLocalDrivingLicenseApp LocalDrivingLicenseApplication;

        public frmTestAppointments(int LocalDrivingLicenseApplication_ID)
        {
            InitializeComponent();
            LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplication_ID;
        }

        void _RefreshTestAppointmentsToDataGrid()
        {
            if (LocalDrivingLicenseApplicationID != -1)
            {
                dgvAppointment.DataSource = LocalDrivingLicenseApplication.ListOfAppointmentForLicenseApplicationID((int)_TestType).DefaultView.ToTable();
            }
            lblRecord.Text = dgvAppointment.Rows.Count.ToString();
        }

        private void TestAppointments_Load(object sender, EventArgs e)
        {
            _LoadData();
            _RefreshTestAppointmentsToDataGrid();
        }

        void _LoadData()
        {
            if (LocalDrivingLicenseApplicationID != -1)
            {
                LocalDrivingLicenseApplication = clsLocalDrivingLicenseApp.FindLocalDrivingLicenseByID(LocalDrivingLicenseApplicationID);
            }
            if (LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID =" + LocalDrivingLicenseApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                uclLocalLicenseApplicationInfo.LoadDataById(LocalDrivingLicenseApplicationID);
            }

        }
        private void btnAddTestAppointment_Click(object sender, EventArgs e)
        {
            if (LocalDrivingLicenseApplication.AppointmentIsLocked((int)_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (LocalDrivingLicenseApplication.PassInTestType((int)_TestType))
            {
                MessageBox.Show("This person already passed this test before, you can only\r\nretake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmTestInfo testInfo = new frmTestInfo(LocalDrivingLicenseApplicationID);
            testInfo.TestType = _TestType;
            testInfo.ShowDialog();
            _RefreshTestAppointmentsToDataGrid();
        }

        private void EditTest_Click(object sender, EventArgs e)
        {
            frmTestInfo testInfo = new frmTestInfo(LocalDrivingLicenseApplicationID,(int)dgvAppointment.CurrentRow.Cells[0].Value);
            testInfo.ShowDialog();
            _RefreshTestAppointmentsToDataGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TakeTest_Click(object sender, EventArgs e)
        {
            if(clsTestAppointment.IsAppointmentAttended((int)dgvAppointment.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("Appointment Already Attended", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmTakeTest takeTest = new frmTakeTest((int)dgvAppointment.CurrentRow.Cells[0].Value);
            takeTest.TestType = _TestType;
            takeTest.ShowDialog();
            _RefreshTestAppointmentsToDataGrid();

        }

       
    }
}
