using DVLDBussinessLayer;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Licenses_And_Driver
{
    public partial class uclDriverLicenseInfoWithFilter : UserControl
    {
        public event Action<int> GetLicenseID;

        protected virtual void ReturnPersonID(int LicenseID)
        {
            Action<int> handler = GetLicenseID;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }

        public uclDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        int _LicenseID = -1;
        public clsLicense SelectedLicense { get { return uclDriverLicenseInfo.SelectedLicense; } }

        private bool _FilterEnable = true;
        public bool FilterEnable
        {
            get { return _FilterEnable; }
            set
            {
                _FilterEnable = value;
                gbFilter.Enabled = _FilterEnable;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txbSearch.Text.Trim() == "")
            {
                return;
            }

            int.TryParse(txbSearch.Text.Trim(), out int LicenseID);
            if (!uclDriverLicenseInfo.LoadDataByLocalLicenseID(LicenseID))
            {
                MessageBox.Show("Error: License is not found with this ID" + LicenseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LicenseID = LicenseID;

            if (GetLicenseID != null)
            {
                GetLicenseID(_LicenseID);
            }
        }


        public bool LoadDataByLicenseID(int LicenseID)
        {
            if (uclDriverLicenseInfo.LoadDataByLocalLicenseID(LicenseID))
            {
                _LicenseID = LicenseID;
                if (GetLicenseID != null)
                {
                    GetLicenseID(_LicenseID);
                }
                return true;
            }
            return false;
        }

        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // لمنع إدخال الحرف
            }
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
