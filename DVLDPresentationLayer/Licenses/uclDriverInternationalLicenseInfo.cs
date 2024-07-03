using DVLDBussinessLayer;
using DVLDPresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Licenses_And_Driver
{
    public partial class uclDriverInternationalLicenseInfo : UserControl
    {
        clsInternationalInternationalLicense _InternationalInternationalLicense;
        public clsInternationalInternationalLicense SelectedInternationalInternationalLicense
        {
            get { return _InternationalInternationalLicense; }
        }

        public uclDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        void _HandleMaleOrFemaleImage()
        {
            if (_InternationalInternationalLicense.Application.Person.Imagepath == null)
            {
                if (_InternationalInternationalLicense.Application.Person.Gender == 0)
                {
                    ProfilePicture.Image = Resources.Person_Male;
                }
                else if (_InternationalInternationalLicense.Application.Person.Gender == 1)
                {
                    ProfilePicture.Image = Resources.Person_Female;
                }
            }
        }

        public bool LoadDataByInternationalLicenseID(int InternationalLicenseId)
        {
            _InternationalInternationalLicense = clsInternationalInternationalLicense.FindInternationalLicenseByID(InternationalLicenseId);
            if (_InternationalInternationalLicense != null)
            {
                _FillInfo();
                return true;
            }
            return false;
        }

        private void _FillInfo()
        {
            
            lblName.Text = _InternationalInternationalLicense.Application.Person.FullName;
            lblLicenseID.Text = _InternationalInternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNational.Text = _InternationalInternationalLicense.Application.Person.NationalNO;
            if (_InternationalInternationalLicense.Application.Person.Gender == 0)
            {
                lblGender.Text = "Male";
            }
            else
            {
                lblGender.Text = "Female";
            }
            lblIssueDate.Text = _InternationalInternationalLicense.IssueDate.ToString();
            lblActive.Text = _InternationalInternationalLicense.IsActive.ToString();
            lblDateBirth.Text = _InternationalInternationalLicense.Application.Person.DateOfBirth.ToString();
            lblDriverID.Text = _InternationalInternationalLicense.DriverID.ToString();
            lblExpirationDate.Text = _InternationalInternationalLicense.ExpirationDate.ToString();
            if (_InternationalInternationalLicense.Application.Person.Imagepath != null)
            {
                try
                {
                    ProfilePicture.Load(_InternationalInternationalLicense.Application.Person.Imagepath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _HandleMaleOrFemaleImage();
            }


        }
    }
}
