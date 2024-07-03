using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer.People
{
    public partial class frmPerosnDetails : Form
    {
        private int _PersonID = 0;
        public frmPerosnDetails(int ID)
        {
            InitializeComponent();
            _PersonID = ID;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uclPersonDetails_Load(object sender, EventArgs e)
        {
           
        }

        private void frmPerosnDetails_Load(object sender, EventArgs e)
        {
           uclPersonDetails.LoadDataByPersonID(_PersonID);
        }
    }
}
