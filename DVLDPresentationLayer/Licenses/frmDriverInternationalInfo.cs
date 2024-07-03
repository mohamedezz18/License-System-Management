using DVLDPresentationLayer.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Licenses_And_Driver
{
    public partial class frmDriverInternationalInfo : Form
    {
        int _InternationalLicenseID = -1;
        public frmDriverInternationalInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLicenseID;
        }

        private void frmDriverInternationalInfo_Load(object sender, EventArgs e)
        {
            _HandleLoadData();
        }

        private void _HandleLoadData()
        {
            if (_InternationalLicenseID != -1)
            {
               uclDriverInternationalLicenseInfo.LoadDataByInternationalLicenseID(_InternationalLicenseID);
            }
            else
            {
                MessageBox.Show("Error: License is not found with this ID" + _InternationalLicenseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
