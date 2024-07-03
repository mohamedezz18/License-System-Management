using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLDPresentationLayer.Properties;

namespace DVLDPresentationLayer.People
{
    public partial class frmAddNewPerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _PersonID = 0;
        clsPerson _Person;

        public frmAddNewPerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            
        }

        public frmAddNewPerson(int ID)
        {
            InitializeComponent();
            _PersonID = ID;
            _Mode = enMode.Update;
            
        }

        void _HandleImage()
        {
            if (ProfilePicture.Image != null && ProfilePicture.Image != Resources.Person_Female
                && ProfilePicture.Image != Resources.Person_Male && !string.IsNullOrEmpty(ProfilePicture.ImageLocation))
            {
                try
                {
                    string sourcePath = ProfilePicture.ImageLocation;
                    string fileName = Path.GetFileName(sourcePath);
                    string destinationFolder = @"D:\Abu-Hadhoud Level 2\DVLD\Profile Image";
                    string destinationPath = Path.Combine(destinationFolder, fileName);

                    if (File.Exists(sourcePath))
                    {
                        // Copy the image file
                        File.Copy(sourcePath, destinationPath, true);



                    }
                    else
                    {
                        MessageBox.Show("Source image file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
        }       

        bool _IsValidEmail(string email)
        {
            var pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email, pattern);
        }

        private void _FillComboxCountries()
        {
            DataTable dtCountries = clsCountry.ListCountry();

            foreach (DataRow row in dtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);

            }
        }

        private void ResetButtons()
        {
            _FillComboxCountries();
            if (_Mode == enMode.AddNew)
            {
                _Person = new clsPerson();
            }
            if (_Mode == enMode.Update)
            {
                lblPersonID.Text = _PersonID.ToString();                
                lblTitle.Text = "Edit Person";
                _Person = clsPerson.FindPersonByID(_PersonID);
            }
            
            dateTimePicker.MaxDate = DateTime.Now.AddYears(-18);
            txtAdress.Text = "";
            txtEmail.Text = "";
            txtThirdName.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            txtPhone.Text = "";
            rbMale.Checked = true;
            txtSecondName.Text = "";                       
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.FindCountryByID(51).CountryName);
        }

        private void SetErrorProvider(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                //e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, "Field is Required!");

            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(textBox, null);
            }
        }

        private bool ShowErrorOnTextbox()
        {
            if (string.IsNullOrWhiteSpace(txtAdress.Text.Trim().ToString()) ||              
               string.IsNullOrWhiteSpace(txtFirstName.Text.Trim().ToString()) ||
               string.IsNullOrWhiteSpace(txtLastName.Text.Trim().ToString()) ||
               string.IsNullOrWhiteSpace(txtNationalNo.Text.Trim().ToString()) ||
               string.IsNullOrWhiteSpace(txtSecondName.Text.Trim().ToString()) ||              
               string.IsNullOrWhiteSpace(txtPhone.Text.Trim().ToString()))
            {
                SetErrorProvider(txtAdress);
                SetErrorProvider(txtPhone);
                SetErrorProvider(txtLastName);
                SetErrorProvider(txtSecondName);
                SetErrorProvider(txtFirstName);
                SetErrorProvider(txtNationalNo);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void _LoadData()
        {    
            if (_Person != null)
            {
                txtAdress.Text = _Person.Address.ToString();
                txtEmail.Text = _Person.Email.ToString();
                txtFirstName.Text = _Person.FirstName.ToString();
                txtSecondName.Text = _Person.SecondName.ToString();
                txtThirdName.Text = _Person.ThirdName.ToString();
                txtLastName.Text = _Person.LastName.ToString();
                txtNationalNo.Text = _Person.NationalNO.ToString();
                txtPhone.Text = _Person.Phone.ToString();
                dateTimePicker.Value = _Person.DateOfBirth;
                if (_Person.Gender == 0)
                {
                    rbMale.Checked = true;                    
                }
                else
                {
                    rbFemale.Checked = true;                  
                }
                cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.FindCountryByID(_Person.NationalityCountryID).CountryName);
                llRemove.Visible = (_Person.Imagepath != null);
                if (_Person.Imagepath != null)
                {
                    try
                    {
                        ProfilePicture.Load(_Person.Imagepath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                {
                    _Person.Imagepath = null;
                }
                _HandleImage();
            }
        }

        private void _SaveData()
        {

            _Person.FirstName = txtFirstName.Text.Trim().ToLower().ToString();
            _Person.LastName = txtLastName.Text.Trim().ToLower().ToString();
            _Person.SecondName = txtSecondName.Text.Trim().ToLower().ToString();
            _Person.ThirdName = txtThirdName.Text.Trim().ToLower().ToString();
            _Person.Address = txtAdress.Text.Trim().ToLower().ToString();
            _Person.Email = txtEmail.Text.Trim().ToLower().ToString();
            _Person.NationalNO = txtNationalNo.Text.Trim().ToLower().ToString();
            _Person.Phone = txtPhone.Text.Trim().ToLower().ToString();
            int CountryID = clsCountry.FindCountryByName(cbCountry.Text.ToString()).CountryID;
            _Person.NationalityCountryID = CountryID;
            _Person.DateOfBirth = dateTimePicker.Value;

            if (rbMale.Checked)
            {
                _Person.Gender = 0;

            }
            else if (rbFemale.Checked)
            {
                _Person.Gender = 1;
            }

            if (ProfilePicture.ImageLocation != null)
            {
                _Person.Imagepath = ProfilePicture.ImageLocation;
            }
            else
            {
                _Person.Imagepath = null;
            }
            llRemove.Visible = (_Person.Imagepath != null);
           
        }

        private void frmAddNewPerson_Load(object sender, EventArgs e)
        {  
            ResetButtons();
            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private bool txtNationalNo_Validating(object sender)
        {
            if (clsPerson.isNationalIDExist(txtNationalNo.Text.Trim().ToString()))
            {
                txtNationalNo.Focus();
                errorProvider1.SetError(txtNationalNo, "National ID Is Used.");
                return true;
            }

            else
            {
                errorProvider1.SetError(txtNationalNo, null);
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ShowErrorOnTextbox())
            {
                return;
            }
            if (!_IsValidEmail(txtEmail.Text.Trim()))
            {
                //SetErrorProvider(txtEmail);
                return;
            }
            _SaveData();
            if (_Person.SavePerson())
            {
                MessageBox.Show("Data Saved Successfully.","Save Data",MessageBoxButtons.OK,MessageBoxIcon.Information);
                _Mode = enMode.Update;
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            _PersonID = _Person.PersonID;
            DataBack?.Invoke(this, _PersonID);
            this.Close();
        }

        private void llSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                ProfilePicture.Load(selectedFilePath);
                // ...
            }
            if (ProfilePicture.Image != null && ProfilePicture.Image != Resources.Person_Female
                && ProfilePicture.Image != Resources.Person_Male)
            {
                llRemove.Visible = true;
            }
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProfilePicture.ImageLocation = null;
            _Person.Imagepath = null;
            MaleOrFemale_CheckedChanged(default,default);
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (clsPerson.isNationalIDExist(txtNationalNo.Text.Trim().ToString()))
            {                
                errorProvider1.SetError(txtNationalNo, "National ID Is Used.");               
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);               
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!_IsValidEmail(txtEmail.Text.Trim().ToString()))
            {
                errorProvider1.SetError(txtEmail, "Email Not Correct");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MaleOrFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked )
            {
                ProfilePicture.Image = Resources.Person_Male;
                llRemove.Visible = false;
            }

            if (rbFemale.Checked )
            {
                ProfilePicture.Image = Resources.Person_Female;
                llRemove.Visible = false;
            }
        }
    }
}
