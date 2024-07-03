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
    public partial class uclUserInfo : UserControl
    {
        private clsUser _User;
        public clsUser SelectedUser
        {
            get
            {
                return _User;
            }
        }

        private int _UserID = -1;

        public uclUserInfo()
        {
            InitializeComponent();
            
        }

        public void LoadDataByUserID(int UserID)
        {
            _User = clsUser.FindUserByID(UserID);
            if(_User == null)
            {
                return;
            }
            _UserID = UserID;
            _FillInfo();
        }

        private void _FillInfo()
        {
            uclPersonDetails.LoadDataByPersonID(_User.Person_ID);
            lblUserID.Text = _UserID.ToString();
            lblUserName.Text = _User.UserName;

            if(_User.IsActived == true)
            {
                lblIsActive.Text = "Yes";
            }
            else
            {
                lblIsActive.Text = "No";
            }
        }

        private void uclPersonDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
