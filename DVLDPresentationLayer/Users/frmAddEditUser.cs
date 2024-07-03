using DVLDBussinessLayer;
using DVLDPresentationLayer.People;
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
    public partial class frmAddEditUser : Form
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        int _PersonID = -1;
        int _UserID = -1;
        clsUser _User ;
        
        public frmAddEditUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
        }

        private void _ResetButtons()
        {
            
            if (_Mode == enMode.AddNew)
            {
                _User = new clsUser();
            }

            if (_Mode == enMode.Update)
            {
                lblUserID.Text = _UserID.ToString();
                lblTitle.Text = "Edit User";
                _User = clsUser.FindUserByID(_UserID);
                uclPersonDetailsWithFilter.FilterEnable = false;
                return;
            }
            lblUserID.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkActive.Checked = true;
        }

        private void _LoadData()
        {
            
            if (_User != null)
            {
               //_PersonID = _User.Person_ID;
                uclPersonDetailsWithFilter.LoadData(_User.Person_ID);
                lblUserID.Text = _User.UserID.ToString();
                txtUsername.Text = _User.UserName;
                txtPassword.Text = _User.Password;
                txtConfirmPassword.Text = _User.Password;
                chkActive.Checked = _User.IsActived;
            }
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetButtons();
            if(_Mode == enMode.Update)
            {
                _LoadData();
            }
            
        }

        void _SaveData()
        {
            _User.Person_ID = _PersonID;
            _User.UserID = _UserID;
            _User.UserName = txtUsername.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActived = chkActive.Checked;
        }

        private bool _SetErrorProvider(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                //e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, "Field is Required!");
                return true;
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(textBox, null);
                return false;
            }
        }
        private bool _ValidateNextTap()
        {
            if(_Mode == enMode.Update)
            {
                return true;
            }

            if (_Mode == enMode.AddNew)
            {

                if (clsUser.isPersonUsed(_PersonID))
                { 
                    MessageBox.Show("Selected Person Already has user, choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabAddEditUser.TabPages["LoginInfo"].Enabled = false;
                    return false;
                }

                if (!clsPerson.isPersonExist(_PersonID))
                {
                    MessageBox.Show("Choose Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabAddEditUser.TabPages["LoginInfo"].Enabled = false;
                    return false;
                }

            }
  
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_ValidateNextTap())
            {
                tabAddEditUser.SelectedTab = LoginInfo;
            }
        }
        
        private void tabAddEditUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabAddEditUser.SelectedTab == LoginInfo)
            {
                if (_ValidateNextTap())
                {
                    //tabAddEditUser.SelectedTab = LoginInfo;
                    tabAddEditUser.TabPages["LoginInfo"].Enabled = true;
                }
                else
                {
                    tabAddEditUser.SelectedTab = PersonInfo;
                    tabAddEditUser.TabPages["LoginInfo"].Enabled = false;
                }
            }
        }



        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                txtPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match password!");

            }

            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = default(char);
                txtConfirmPassword.PasswordChar = default(char);
            }

            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
            }
        }

        private void uclPersonDetailsWithFilter_GetPersonID(int obj)
        {
            _PersonID = obj;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_SetErrorProvider(txtUsername) || _SetErrorProvider(txtPassword) || _SetErrorProvider(txtConfirmPassword))
            {
                return;
            }
            _SaveData();
            if (_User.SaveUser())
            {
                MessageBox.Show("Data Saved Successfully.", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;

            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
