using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Licenses_And_Driver
{
    public partial class frmDriverList : Form
    {
        private static DataTable _AllDrivers = clsDriver.GetAllDrivers();
        private DataTable _dtDrivers = _AllDrivers.DefaultView.Table;
        public frmDriverList()
        {
            InitializeComponent();
        }

        void _RefreshDataToGrid()
        {
            _AllDrivers = clsDriver.GetAllDrivers();
            _dtDrivers = _AllDrivers.DefaultView.Table;
            dgvDrivers.DataSource = _dtDrivers;
            lblRecord.Text = dgvDrivers.Rows.Count.ToString();
        }

        private string _Filter()
        {
            switch (cbFilter.Text)
            {
                case "None":
                    return "None";
                case "PersonID":
                    return "PersonID";
                case "DriverID":
                    return "DriverID";
                case "National No":
                    return "National No";
                case "Full Name":
                    return "Full Name";
                default:
                    return "";
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbSearch.Visible = (cbFilter.Text != "None" && cbFilter.Text != "");
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = _Filter();
            if (txbSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtDrivers.DefaultView.RowFilter = "";
                lblRecord.Text = _dtDrivers.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "PersonID" || FilterColumn == "DriverID")
            {
                _dtDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txbSearch.Text.Trim());
            }
            else
            {
                _dtDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txbSearch.Text.Trim());
            }
            lblRecord.Text = dgvDrivers.Rows.Count.ToString();

        }

        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Filter() == "PersonID" || _Filter() == "DriverID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // لمنع إدخال الحرف
                }
            }
        }

        private void frmDriverList_Load(object sender, EventArgs e)
        {
            _RefreshDataToGrid();
        }
    }
}
