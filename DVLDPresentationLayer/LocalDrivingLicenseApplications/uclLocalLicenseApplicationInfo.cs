using DVLDBussinessLayer;
using DVLDPresentationLayer.People;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer.LocalDrivingLicenseApplications
{
    public partial class uclLocalLicenseApplicationInfo : UserControl
    {
        private clsLocalDrivingLicenseApp _LocalDrivingLicenseApplications;
        public clsLocalDrivingLicenseApp LocalDrivingLicenseApplications
        {
            get { return _LocalDrivingLicenseApplications; }
        }

        public uclLocalLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadDataById(int LocalLicenseAppID)
        {
            _LocalDrivingLicenseApplications = clsLocalDrivingLicenseApp.FindLocalDrivingLicenseByID(LocalLicenseAppID);
            if (_LocalDrivingLicenseApplications == null)
            {
                return;
            }
            _FillInfo();

        }

        private void _FillInfo()
        {
            lblLicenseAppID.Text = _LocalDrivingLicenseApplications.LocalDrivingLicenseID.ToString();
            lblLicenseClass.Text = _LocalDrivingLicenseApplications.LicenseClasses.ClassName;
            lblPassedTest.Text = _LocalDrivingLicenseApplications.PassedTestsCount().ToString();
            uclApplicationInfo1.LoadApplicationData(_LocalDrivingLicenseApplications.ApplicationID);
        }
    }
}
