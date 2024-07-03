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

namespace DVLDPresentationLayer.Users
{
    public partial class frmChangePassword : Form
    {
        int _UserID = -1;
        clsUser _User;

        public frmChangePassword(int userId)
        {
            InitializeComponent();
            _UserID = userId;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
             _LoadData();
        }

        void _LoadData()
        {
            _User = clsUser.FindUserByID( _UserID );
            if(_User != null)
            {
                uclUserInfo.LoadDataByUserID( _UserID );
            }
        }

        private void _SetErrorProvider(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                //e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, "Field is Required!");

            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(textBox, null);
            }
        }

        private bool _ShowErrorOnTextbox()
        {
            if (string.IsNullOrWhiteSpace(txbNewPassword.Text.Trim().ToString()) ||
               string.IsNullOrWhiteSpace(txbConfirmPassword.Text.Trim().ToString()) ||
               string.IsNullOrWhiteSpace(txbCurrentPassword.Text.Trim().ToString())
               )
            {
                _SetErrorProvider(txbNewPassword);
                _SetErrorProvider(txbConfirmPassword);
                _SetErrorProvider(txbCurrentPassword);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool txbCurrentPassword_Validating()
        {
            if (txbCurrentPassword.Text != _User.Password)
            {
                MessageBox.Show("Error: Current Password Is Wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txbCurrentPassword, "Current Password Is Wrong");
                return true;
            }
            else
            {
                errorProvider1.SetError(txbCurrentPassword, null);
                return false;
            }
        }

        private bool txbConfirmPassword_Validating()
        {
            if(txbConfirmPassword.Text != txbNewPassword.Text)
            {
                MessageBox.Show("Error: Passwords Is Not Confirm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txbConfirmPassword, "Passwords Is Not Confirm.");
                return true ;
            }
            else
            {
                errorProvider1.SetError(txbConfirmPassword, null);
                return false ;
            }
        }

        void _SavePassword()
        {
            _User.Password = txbNewPassword.Text.Trim();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_ShowErrorOnTextbox() || txbCurrentPassword_Validating() || txbConfirmPassword_Validating() )
            {
              
                return;
            }
            _User.Password = txbNewPassword.Text.Trim();
            if (_User.SaveUser())
            {
                MessageBox.Show("Data Saved Successfully.", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
