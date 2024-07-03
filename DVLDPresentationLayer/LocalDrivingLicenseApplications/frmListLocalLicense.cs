using DVLDBussinessLayer;
using DVLDPresentationLayer.Licenses;
using DVLDPresentationLayer.Test;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLDPresentationLayer.LocalDrivingLicenseApplications
{
    public partial class frmListLocalLicense : Form
    {
        private static DataTable _AllLocalLicenseApplications = clsLocalDrivingLicenseApp.GetAllApplicationsForLocalLicense();
        private DataTable _dtLocalLocalLicenseApplications = _AllLocalLicenseApplications.DefaultView.ToTable();

        clsLocalDrivingLicenseApp LocalDrivingLicense;
        public frmListLocalLicense()
        {
            InitializeComponent();
        }

        void _RefreshDataToGrid()
        {
            _AllLocalLicenseApplications = clsLocalDrivingLicenseApp.GetAllApplicationsForLocalLicense();
            _dtLocalLocalLicenseApplications = _AllLocalLicenseApplications.DefaultView.Table;
            dgvApplicationLocalLicense.DataSource = _dtLocalLocalLicenseApplications;
            lblRecord.Text = dgvApplicationLocalLicense.Rows.Count.ToString();
        }
        private void _HandleSechduleTest()
        {
            if (!LocalDrivingLicense.PassInTestType((int)clsTestTypes.enTestType.VisionTest))
            {
                visionTestToolStripMenuItem.Enabled = true;
                writtenToolStripMenuItem.Enabled = false;
                practicalTestToolStripMenuItem.Enabled = false;
                return;
            }
            else if (!LocalDrivingLicense.PassInTestType((int)clsTestTypes.enTestType.WriteTest))
            {
                visionTestToolStripMenuItem.Enabled = false;
                writtenToolStripMenuItem.Enabled = true;
                practicalTestToolStripMenuItem.Enabled = false;
                return;
            }
            else if (!LocalDrivingLicense.PassInTestType((int)clsTestTypes.enTestType.StreetTest))
            {
                visionTestToolStripMenuItem.Enabled = false;
                writtenToolStripMenuItem.Enabled = false;
                practicalTestToolStripMenuItem.Enabled = true;
                return;

            }
            return;
        }

        void _HandleIssueLicense()
        {
            if (LocalDrivingLicense.PassInTestType((int)clsTestTypes.enTestType.VisionTest) && LocalDrivingLicense.PassInTestType((int)clsTestTypes.enTestType.WriteTest) && LocalDrivingLicense.PassInTestType((int)clsTestTypes.enTestType.StreetTest))
            {
                SechduleTest.Enabled = false;
                IssueLicense.Enabled = true;
                return;
            }
            else
            {
                SechduleTest.Enabled = true;
                IssueLicense.Enabled = false;
            }
        }

        void _HandleCancelAndEditAndDeleteApplication()
        {
            if (LocalDrivingLicense.ApplicationInfo.ApplicationStatus == clsApplcation.enApplicationStatus.Completed)
            {
                CancelApplication.Enabled = false;
                EditApplication.Enabled = false;
                DeleteApplication.Enabled = false;

            }
            else
            {
                CancelApplication.Enabled = true;
                EditApplication.Enabled = true;
                DeleteApplication.Enabled = true;

            }

        }

        void _HandleShowLicense()
        {
            if (LocalDrivingLicense.GetLicenseId() != -1)
            {
                ShowLicense.Enabled = true;
                IssueLicense.Enabled = false;
            }
            else
            {
                ShowLicense.Enabled = false;

            }
        }

        private void frmListLocalLicense_Load(object sender, EventArgs e)
        {
            _RefreshDataToGrid();
            cbFilter.SelectedIndex = 0;

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddLocalDrivingLicenseApplications addLocalDrivingLicenseApplications = new frmAddLocalDrivingLicenseApplications();
            addLocalDrivingLicenseApplications.ShowDialog();
            _RefreshDataToGrid();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbSearch.Visible = (cbFilter.Text != "None" && cbFilter.Text != "Status");
            cbStatus.Visible = (cbFilter.Text == "Status");
        }

        private string _Filter()
        {
            switch (cbFilter.Text)
            {
                case "None":
                    return "None";
                case "L.D.L AppID":
                    return "LocalDrivingLicenseApplicationID";
                case "Full Name":
                    return "FullName";
                case "National NO":
                    return "NationalNo";
                case "Status":
                    return "Status";
                default:
                    return "";
            }
        }


        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.Text != "" || cbStatus.Text != "All")
            {
                _dtLocalLocalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", "Status", cbStatus.Text);

            }
            else if (cbStatus.Text == "All")
            {
                _RefreshDataToGrid();
            }
            lblRecord.Text = dgvApplicationLocalLicense.Rows.Count.ToString();

        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = _Filter();
            if (txbSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtLocalLocalLicenseApplications.DefaultView.RowFilter = "";
                lblRecord.Text = _dtLocalLocalLicenseApplications.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "LocalDrivingLicenseApplicationID")
            {
                _dtLocalLocalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txbSearch.Text.Trim());
            }
            else
            {
                _dtLocalLocalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txbSearch.Text.Trim());
            }
            lblRecord.Text = dgvApplicationLocalLicense.Rows.Count.ToString();
        }

        private void CancelApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancel this Application [" + dgvApplicationLocalLicense.CurrentRow.Cells[0].Value + "]", "Cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (LocalDrivingLicense.ApplicationInfo.Cancel())
                {
                    MessageBox.Show("Application Cancel Successfully.", "Cancel Application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _RefreshDataToGrid();
                }
                else
                {
                    MessageBox.Show("Application Not Cancel Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments testAppointments = new frmTestAppointments((int)dgvApplicationLocalLicense.CurrentRow.Cells[0].Value);
            testAppointments.TestType = clsTestTypes.enTestType.VisionTest;
            testAppointments.ShowDialog();
            _RefreshDataToGrid();
        }

        private void cmsTools_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LocalDrivingLicense = clsLocalDrivingLicenseApp.FindLocalDrivingLicenseByID((int)dgvApplicationLocalLicense.CurrentRow.Cells[0].Value);

            if (LocalDrivingLicense == null)
            {
                MessageBox.Show("Error: LocalDrivingLicense Not Found With ID [" + dgvApplicationLocalLicense.CurrentRow.Cells[0].Value + "].", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmsTools.Close();
                return;
            }
            _HandleSechduleTest();
            _HandleIssueLicense();
            _HandleCancelAndEditAndDeleteApplication();
            _HandleShowLicense();

        }

        private void DeleteApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Local Driving Application [" + dgvApplicationLocalLicense.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApp.DeleteLocalDrivingApplication(LocalDrivingLicense.ApplicationID))
                {
                    MessageBox.Show("Local Driving Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _RefreshDataToGrid();
                }
                else
                {
                    MessageBox.Show("Local Driving Application Not Deleted Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void IssueLicense_Click(object sender, EventArgs e)
        {
            frmAddLicense addLicense = new frmAddLicense(LocalDrivingLicense.LocalDrivingLicenseID);
            addLicense.ShowDialog();
            _RefreshDataToGrid();
        }

        private void ShowLicense_Click(object sender, EventArgs e)
        {
            frmLicenseInfo licenseInfo = new frmLicenseInfo(LocalDrivingLicense.GetLicenseId());
            licenseInfo.ShowDialog();

        }

        private void writtenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments testAppointments = new frmTestAppointments((int)dgvApplicationLocalLicense.CurrentRow.Cells[0].Value);
            testAppointments.TestType = clsTestTypes.enTestType.WriteTest;
            testAppointments.ShowDialog();
            _RefreshDataToGrid();
        }

        private void practicalTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments testAppointments = new frmTestAppointments((int)dgvApplicationLocalLicense.CurrentRow.Cells[0].Value);
            testAppointments.TestType = clsTestTypes.enTestType.StreetTest;
            testAppointments.ShowDialog();
            _RefreshDataToGrid();
        }

        private void EditApplication_Click(object sender, EventArgs e)
        {
            frmAddLocalDrivingLicenseApplications EditLocalDrivingLicenseApplications = new frmAddLocalDrivingLicenseApplications(LocalDrivingLicense.LocalDrivingLicenseID);
            EditLocalDrivingLicenseApplications.ShowDialog();
            _RefreshDataToGrid();
        }
    }
}
