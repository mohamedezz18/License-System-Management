using DVLDBussinessLayer;
using DVLDPresentationLayer.Licenses;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Licenses_And_Driver
{
    public partial class frmDriverAllLicense : Form
    {
        int _PersonID = -1;

        clsDriver _Driver;
        public frmDriverAllLicense(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        void _RefreshDataToGrid()
        {
            dgvInternational.DataSource = _Driver.GetInternationalLicenseHistory().DefaultView.Table;
            dgvLocal.DataSource = _Driver.GetLocalLicenseHistory().DefaultView.Table;
        }

        void _HandleLoadData()
        {
            _Driver = clsDriver.FindDriverByPersonID(_PersonID);
            if (_Driver != null && _PersonID != -1)
            {
                uclPersonDetailsWithFilter1.LoadData(_PersonID);
                _RefreshDataToGrid();
            }
            else
            {
                MessageBox.Show("Error: Driver Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void frmDriverAllLicense_Load(object sender, System.EventArgs e)
        {
            _HandleLoadData();
        }

        private void ShowLicenseInfo_Click(object sender, System.EventArgs e)
        {
            if(tabControl.SelectedTab == Local)
            {
                frmLicenseInfo licenseInfo = new frmLicenseInfo((int)(dgvLocal.CurrentRow.Cells[0].Value));
                licenseInfo.ShowDialog();
            }
            else if (tabControl.SelectedTab == International)
            {
              frmDriverInternationalInfo driverInternationalInfo = new frmDriverInternationalInfo((int)(dgvInternational.CurrentRow.Cells[0].Value));
              driverInternationalInfo.ShowDialog();
            }
            return;
        }
    }
}
