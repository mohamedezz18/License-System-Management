using DVLDBussinessLayer;
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
    public partial class frmTestInfo : Form
    {
        public clsTestTypes.enTestType TestType
        {
            get { return uclTestInfo.TestType; }
            set
            {
                uclTestInfo.TestType = value;
            }
        }

        int TestAppointmentID = -1;

        int LocalDrivingLicenseApplicationID = -1;
       
        public frmTestInfo(int LocalDrivingLicenseApplicationId, int TestAppointmentId)
        {
            InitializeComponent();
            LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationId;
            TestAppointmentID = TestAppointmentId;
        }

        public frmTestInfo(int LocalDrivingLicenseApplicationId)
        {
            InitializeComponent();
            LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationId;
        }

        private void frmTestInfo_Load(object sender, EventArgs e)
        {
           uclTestInfo.LoadInfo(LocalDrivingLicenseApplicationID, TestAppointmentID);
        }

        private void uclTestInfo_CheckSavedData(bool obj)
        {
            if (obj)
            {
                this.Close();
            }
        }
    }
}
