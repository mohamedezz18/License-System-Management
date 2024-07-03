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

namespace DVLDPresentationLayer.Applications
{
    public partial class uclApplicationInfo : UserControl
    {
        private clsApplcation _Application;
        public clsApplcation Application { get { return _Application; } }

        public uclApplicationInfo()
        {
            InitializeComponent();
        }

       

        public void LoadApplicationData(int Applicatinid)
        {
            _Application = clsApplcation.GetApplicationByID(Applicatinid);
            if (_Application == null)
            {
                return; 
            }
            _FillInfo();
        }

        private void _FillInfo()
        {
            lblID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.ApplicationStatus.ToString();
            lblFees.Text = _Application.PaidFees.ToString();
            lblType.Text = _Application.ApplicationType.ApplicationTypeTitle;
            lblPerson.Text = _Application.Person.FullName;
            lblDate.Text = _Application.ApplicationDate.ToString();
            lblDateStatus.Text = _Application.LastStatusDate.ToString();
            lblUser.Text = _Application.CurrentUser.UserName;
        }


        private void gbAppBasicInfo_Enter(object sender, EventArgs e)
        {

        }

        private void llPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPerosnDetails PersonDetails = new frmPerosnDetails(_Application.ApplicantPersonID);
            PersonDetails.ShowDialog();
        }
    }
}
