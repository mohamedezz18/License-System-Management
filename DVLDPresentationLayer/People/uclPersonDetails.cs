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
using TheArtOfDevHtmlRenderer.Adapters;

namespace DVLDPresentationLayer.People
{
    public partial class uclPersonDetails : UserControl
    {
        private int _PersonId = -1;
        public int PersonId
        {
            get { return _PersonId; }
        }

        private clsPerson _Person;
        public clsPerson SelectedPerson
        {
            get { return _Person; }
        }

        public uclPersonDetails()
        {
            InitializeComponent();

        }


        public bool LoadDataByPersonID(int PersonID)
        {
            _Person = clsPerson.FindPersonByID(PersonID);
            if (_Person == null)
            {
                ResetButtons();
                return false;
            }
            else
            {
                _PersonId = _Person.PersonID;
                _FillInfo();
                return true;
            }
        }

        public void LoadDataByNationalNO(string NationalNo)
        {
            _Person = clsPerson.FindPersonByNationalNO(NationalNo);
            if (_Person == null)
            {
                ResetButtons();
                return;
            }
            _PersonId = _Person.PersonID;
            _FillInfo();
        }

        private void ResetButtons()
        {
            _PersonId = -1;
            lblAdress.Text = "{????}";
            lblCountry.Text = "{????}";
            lblDate.Text = "{????}";
            lblName.Text = "{????}";
            lblNationalNo.Text = "{????}";
            lblPersonID.Text = "{????}";
            lblEmail.Text = "{????}";
            lblGender.Text = "{????}";
            lblPhone.Text = "{????}";
            ProfilePicture.Image = null;

        }

        private void _FillInfo()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            lblName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNO.ToString();
            lblPhone.Text = _Person.Phone.ToString();
            lblDate.Text = _Person.DateOfBirth.ToString();
            if (_Person.Gender == 0)
            {
                lblGender.Text = "Male";
            }
            else
            {
                lblGender.Text = "Female";
            }
            lblCountry.Text = clsCountry.FindCountryByID(_Person.NationalityCountryID).CountryName;
            lblAdress.Text = _Person.Address;
            lblEmail.Text = _Person.Email;
            if (_Person.Imagepath != null)
            {
                try
                {
                    ProfilePicture.Load(_Person.Imagepath);
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

        void _HandleMaleOrFemaleImage()
        {
            if (_Person.Imagepath == null)
            {
                if (_Person.Gender == 0 )
                {
                    ProfilePicture.Image = Resources.Person_Male;
                }

                else if (_Person.Gender == 1)
                {
                    ProfilePicture.Image = Resources.Person_Female;
                }
            }
        }
        
        private void llEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddNewPerson EdtitPerson = new frmAddNewPerson(_PersonId);
            EdtitPerson.DataBack += EditPersonDataBack;
            EdtitPerson.ShowDialog();
        }

        private void EditPersonDataBack(object sender, int PersonID)
        {
            LoadDataByPersonID(PersonID);
        }

        
    }
}
