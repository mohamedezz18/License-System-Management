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
    public partial class frmEditTestType : Form
    {

        int ID = -1;
        clsTestTypes TestTypes;

        public frmEditTestType(int id)
        {
            InitializeComponent();
            ID = id;
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        void _LoadData()
        {
            TestTypes = clsTestTypes.FindTestTypeByID(ID);
            if (TestTypes != null)
            {
                lblID.Text = TestTypes.TestTypeID.ToString();
                txbTitle.Text = TestTypes.TypeTitle.ToString().Trim();
                txbFees.Text = TestTypes.TypeFees.ToString().Trim();
                txbDescription.Text = TestTypes.TypeDescription.ToString().Trim();
            }
        }

        bool _SetErrorPervider(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                errorProvider1.SetError(textBox, "Field Is Requirement");
                return true;
            }
            else
            {
                errorProvider1.SetError(textBox, null);
                return false;
            }

        }

        void _SaveData()
        {
            TestTypes.TypeTitle = txbTitle.Text;
            TestTypes.TypeFees = Convert.ToSingle(txbFees.Text);
            TestTypes.TypeDescription = txbDescription.Text.Trim();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_SetErrorPervider(txbTitle) || _SetErrorPervider(txbFees) || _SetErrorPervider(txbDescription))
            {
                return;
            }

            _SaveData();
            if (TestTypes.SaveUpdate())
            {
                MessageBox.Show("Data Saved Successfully.", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
