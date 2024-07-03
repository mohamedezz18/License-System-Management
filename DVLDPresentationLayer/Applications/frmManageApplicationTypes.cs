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

namespace DVLDPresentationLayer.Applications
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        void _RefreshData()
        {
            dgvTypes.DataSource = clsApplicationTypes.GetAllApplicationTypes();
            lblRecord.Text = dgvTypes.Rows.Count.ToString();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationType_Click(object sender, EventArgs e)
        {
            frmEditApplicationType editApplicationType = new frmEditApplicationType((int)dgvTypes.CurrentRow.Cells[0].Value);
            editApplicationType.ShowDialog();
            _RefreshData();
        }
    }
}
