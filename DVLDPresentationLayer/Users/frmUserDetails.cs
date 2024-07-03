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
    public partial class frmUserDetails : Form
    {
        int _UserID = -1;
        public frmUserDetails(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uclUserInfo1_Load(object sender, EventArgs e)
        {
            uclUserInfo.LoadDataByUserID(_UserID);
        }
    }
}
