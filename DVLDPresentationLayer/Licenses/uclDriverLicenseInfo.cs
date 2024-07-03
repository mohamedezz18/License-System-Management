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

namespace DVLDPresentationLayer.Licenses
{
    public partial class uclDriverLicenseInfo : UserControl
    {
        private clsLicense _License;
        public clsLicense SelectedLicense { get { return _License; } }

        public uclDriverLicenseInfo()
        {
            InitializeComponent();
            
        }

        void _HandleMaleOrFemaleImage()
        {
            if (_License.Driver.Person.Imagepath == null)
            {
                if (_License.Driver.Person.Gender == 0 )
                {
                    ProfilePicture.Image = Resources.Person_Male;
                }

                else if (_License.Driver.Person.Gender == 1 )
                {
                    ProfilePicture.Image = Resources.Person_Female;
                }
            }
        }


        public bool LoadDataByLocalLicenseID(int LicenseId)
        {
            _License = clsLicense.FindLicenseByID(LicenseId);
            if (_License != null && _License.Driver != null)
            {
                _FillInfo();
                return true;
            }
            return false;
        }

        private void _FillInfo()
        {
            lblClass.Text = _License.LicenseClasse.ClassName;
            lblName.Text = _License.Driver.Person.FullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNational.Text = _License.Driver.Person.NationalNO;
            if (_License.Driver.Person.Gender == 0)
            {
                lblGender.Text = "Male";
            }
            else
            {
                lblGender.Text = "Female";
            }
            lblIssueDate.Text = _License.IssueDate.ToString();
            lblIssueReason.Text = _License.IssueReason.ToString();
            if(_License.Notes != null)
            {
                lblNotes.Text = _License.Notes.ToString();
            }
            else
            {
                lblNotes.Text = "No Notes";
            }
            lblActive.Text = _License.IsActive.ToString();
            lblDateBirth.Text = _License.Driver.Person.DateOfBirth.ToString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToString();
            if(_License.Driver.Person.Imagepath != null)
            {
                try
                {
                    ProfilePicture.Load(_License.Driver.Person.Imagepath);
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
