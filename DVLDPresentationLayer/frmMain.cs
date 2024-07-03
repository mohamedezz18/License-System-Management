using DVLDPresentationLayer.Applications;
using DVLDPresentationLayer.Licenses_And_Driver;
using DVLDPresentationLayer.LocalDrivingLicenseApplications;
using DVLDPresentationLayer.People;
using DVLDPresentationLayer.Users;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class frmMain : Form
    {
        //to change Color
        Guna2Button CurrentButton;
        Guna2Button LastButton;

        //Open ChildForm
        public void OpenForm(object Form)
        {
            if (PanelMain.Controls.Count > 0)
            {
                PanelMain.Controls.RemoveAt(0);
            }
            Form form = Form as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            //form.StartPosition = FormStartPosition.CenterParent;
            this.PanelMain.Controls.Add(form);
            this.PanelMain.Tag = form;
            form.Show();
        }


        public frmMain()
        {
            InitializeComponent();
            

        }


        private void btnMinmized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_MouseClick(object sender, MouseEventArgs e)
        {
            LastButton = CurrentButton;
            CurrentButton = (Guna2Button)sender;
            CurrentButton.ForeColor = Color.Black;
            CurrentButton.BackColor = Color.WhiteSmoke;
            if (LastButton != null)
            {
                LastButton.BackColor = Color.Transparent;
                LastButton.ForeColor = Color.WhiteSmoke;
            }
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            //frmPeople people = new frmPeople();
            //people.ShowDialog();

            OpenForm(new frmPeople());

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinmized_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (clsGlobalUser.CurrentUser.Imagepath != null)
            {
                try
                {
                    PictureProfile.Load(clsGlobalUser.CurrentUser.Imagepath);
                }
                catch
                {
                    
                }
            }
            lblUserName.Text = clsGlobalUser.CurrentUser.FirstName + " " + clsGlobalUser.CurrentUser.SecondName;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLoginScree loginScreen = new frmLoginScree();
            loginScreen.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenForm(new frmUsers());
        }

        private void btnAccountSettings_Click_1(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs != null && mouseEventArgs.Button == MouseButtons.Left)
            {
                cmsAccountSettings.Show(btnAccountSettings, mouseEventArgs.Location);
            }
        }

        private void CurrentUserInfo_Click(object sender, EventArgs e)
        {
            frmUserDetails CurrentUserInfo = new frmUserDetails(clsGlobalUser.CurrentUser.UserID);
            CurrentUserInfo.BackColor = Color.DarkGray;
            CurrentUserInfo.ShowDialog();
            //OpenChildForm(CurrentUserInfo);

        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(clsGlobalUser.CurrentUser.UserID);
            changePassword.BackColor = Color.DarkGray;
            changePassword.ShowDialog();
            //OpenChildForm(new frmChangePassword(clsGlobalUser.CurrentUser.UserID));


        }

        private void btnApplications_Click(object sender, EventArgs e)
        {
            frmApplication application = new frmApplication(this);
          
            OpenForm(application);
           
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            frmDriverList driverList = new frmDriverList();
            OpenForm(driverList);
        }
    }
}
