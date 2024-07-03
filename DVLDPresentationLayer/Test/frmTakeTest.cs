using DVLDBussinessLayer;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Test
{
    public partial class frmTakeTest : Form
    {
        public clsTestTypes.enTestType TestType
        {
            get { return uclReadTestInfo.TestType; }
            set
            {
                uclReadTestInfo.TestType = value;
            }
        }
        int TestAppointmentID = -1;
        clsTest Test;


        public frmTakeTest(int TestAppointmentId)
        {
            InitializeComponent();
            TestAppointmentID = TestAppointmentId;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _HandleLoadData();
        }

        void _HandleLoadData()
        {
            if (!uclReadTestInfo.LoadDataByID(TestAppointmentID))
            {
                MessageBox.Show("Error: Failed To Load Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Test = new clsTest();
        }

        void _SaveData()
        {
            Test.TestAppointmentID = TestAppointmentID;
            if (rbPass.Checked)
            {
                Test.TestResult = true;
            }
            else
            {
                Test.TestResult = false;
            }
            if (txbNote.Text.Trim() != "")
            {
                Test.Notes = txbNote.Text.Trim();
            }
            else
            {
                Test.Notes = null;
            }
            Test.UserID = clsGlobalUser.CurrentUser.UserID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveData();
            if (Test.SaveTest())
            {
                MessageBox.Show("Test Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsTestAppointment.LockedTestAppointment(TestAppointmentID);
                this.Close();
            }
            else
            {

                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
