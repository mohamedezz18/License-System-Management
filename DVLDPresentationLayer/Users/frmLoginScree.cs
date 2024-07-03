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
    public partial class frmLoginScree : Form
    {

        private enum enLoginStatus { eSuccess, eFailedUserNotFound, eFailedPasswordWrong, eUserEmpty, ePasswordEmpty,eUserIsNotActive };


        public frmLoginScree()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkshowpass_CheckedChanged(object sender, EventArgs e)
        {

            if (chkshowpass.Checked)
            {
                txtPassword.PasswordChar = default(char);
            }

            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private enLoginStatus _LoginAccount()
        {
            string Username = txtUsername.Text.Trim();
            string Password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(Username))
            {
                lblInvailedUser.Visible = true;
                lblInvailedUser.Text = "UserName Is Empty";
                return enLoginStatus.eUserEmpty;
            }

            if (string.IsNullOrEmpty(Password))
            {
                lblInvailedPassword.Visible = true;
                lblInvailedPassword.Text = "Password Is Empty";
                return enLoginStatus.ePasswordEmpty;
            }

            clsUser User = clsUser.FindUserByUsername(Username);
            if (User == null)
            {
                lblInvailedUser.Visible = true;
                lblInvailedUser.Text = "Invailed UserName";
                return enLoginStatus.eFailedUserNotFound;
            }

            if (User.Password != Password)
            {
                lblInvailedPassword.Visible = true;
                lblInvailedPassword.Text = "Invailed Password";
                return enLoginStatus.eFailedPasswordWrong;
            }

            if(User.IsActived != true)
            {
                return enLoginStatus.eUserIsNotActive;
            }

            clsGlobalUser.CurrentUser = User;
            return enLoginStatus.eSuccess;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            enLoginStatus loginStatus = _LoginAccount();
            if (loginStatus == enLoginStatus.eSuccess)
            {

                this.Hide();
                frmMain frmMain = new frmMain();
                frmMain.ShowDialog();
                frmMain = null;
                Application.Exit();
            }
            else if (loginStatus == enLoginStatus.eUserIsNotActive)
            {
                MessageBox.Show("User Is Not Active", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Invailed Username Or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmLoginScree_Load(object sender, EventArgs e)
        {
            
        }
    }
}
