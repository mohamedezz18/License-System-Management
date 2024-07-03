using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Licenses
{
    public partial class frmLicenseInfo : Form
    {
        int LicesnseID;
        public frmLicenseInfo(int LicesnseId)
        {
            InitializeComponent();
            LicesnseID = LicesnseId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            _HandleLoadData();
        }

        private void _HandleLoadData()
        {
            if (LicesnseID != -1)
            {
                uclDriverLicenseInfo.LoadDataByLocalLicenseID(LicesnseID);
            }
            else
            {
                MessageBox.Show("Error: License is not found with this ID" + LicesnseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
