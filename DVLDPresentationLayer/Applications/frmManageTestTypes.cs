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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        void _RefreshData()
        {
            dgvTestTypes.DataSource = clsTestTypes.GetAllTestTypes();
            lblRecord.Text = dgvTestTypes.Rows.Count.ToString();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTestType_Click(object sender, EventArgs e)
        {
            frmEditTestType editTestType = new frmEditTestType((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            editTestType.ShowDialog();
            _RefreshData();
        }
    }
}
