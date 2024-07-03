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
    public partial class frmEditApplicationType : Form
    {
        int ID = -1;
        clsApplicationTypes ApplicationTypes;


        public frmEditApplicationType(int id)
        {
            InitializeComponent();
            ID = id;
        }

        void _LoadData()
        {
            ApplicationTypes =clsApplicationTypes.FindApplicationTypeByID(ID);
            if(ApplicationTypes != null)
            {
                lblID.Text = ApplicationTypes.ApplicationTypeID.ToString();
                txbTitle.Text = ApplicationTypes.ApplicationTypeTitle.ToString().Trim();
                txbFees.Text = ApplicationTypes.ApplicationTypeFees.ToString().Trim();
            }
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        void _SaveData()
        {
            ApplicationTypes.ApplicationTypeTitle = txbTitle.Text;
            ApplicationTypes.ApplicationTypeFees = Convert.ToSingle(txbFees.Text);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_SetErrorPervider(txbTitle) || _SetErrorPervider(txbFees))
            {
                return;
            }

            _SaveData();
            if (ApplicationTypes.SaveUpdate())
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
