using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsPerson
    {
        private enum enModePerson { AddNew = 0, Update = 1 };
        private enModePerson ModePR = enModePerson.AddNew;

        public int PersonID { get; set; }
        public string NationalNO { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            }
        }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string Imagepath { get; set; }
        private clsCountry _CountryInfo;

        public clsCountry CountryInfo
        {
            get
            {
                return _CountryInfo;
            }
        }
       

        private clsPerson(int ID, string National_NO, string Firstname, string Secondname,
            string Thirdname, string Lastname, DateTime DateOfbirth, byte gendor, string address
            , string phone, string email, int NationalityCountry_ID, string imagepath)
        {
            this.PersonID = ID;
            this.NationalNO = National_NO;
            this.FirstName = Firstname;
            this.SecondName = Secondname;
            this.ThirdName = Thirdname;
            this.LastName = Lastname;
            this.DateOfBirth = DateOfbirth;
            this.Gender = gendor;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.NationalityCountryID = NationalityCountry_ID;
            this.Imagepath = imagepath;
            this._CountryInfo = clsCountry.FindCountryByID(NationalityCountryID);
            ModePR = enModePerson.Update;
        }

        public clsPerson()
        {
            PersonID = -1;
            NationalNO = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = default;
            Gender = 0;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = 0;
            Imagepath = "";
            ModePR = enModePerson.AddNew;
        }

        public static clsPerson FindPersonByID(int ID)
        {
            string nationalNO = null, firstname = null, lastname = null, thirdname = null, secondname = null,
                adress = null, phone = null, email = null, imagepath = null;
            int NationalityCountryid = 0;
            byte gender = 0; DateTime dateofbirth = default;

            if (PersonData.GetPersonByID(ID, ref nationalNO, ref firstname, ref secondname, ref thirdname, ref lastname,
                ref dateofbirth, ref gender, ref adress, ref phone, ref email, ref NationalityCountryid, ref imagepath))
            {
                return new clsPerson(ID, nationalNO, firstname, secondname, thirdname, lastname,
                    dateofbirth, gender, adress, phone, email, NationalityCountryid, imagepath);
            }
            else
            {
                return null;
            }

        }

        public static clsPerson FindPersonByNationalNO(string National_NO)
        {
            string firstname = null, lastname = null, thirdname = null, secondname = null,
                adress = null, phone = null, email = null, imagepath = null;
            int NationalityCountryid = 0, ID = 0;
            byte gender = 0; DateTime dateofbirth = default;

            if (PersonData.GetPersonByNationalNO(ref ID, National_NO, ref firstname, ref secondname, ref thirdname, ref lastname,
                ref dateofbirth, ref gender, ref adress, ref phone, ref email, ref NationalityCountryid, ref imagepath))
            {
                return new clsPerson(ID, National_NO, firstname, secondname, thirdname, lastname,
                    dateofbirth, gender, adress, phone, email, NationalityCountryid, imagepath);
            }
            else
            {
                return null;
            }

        }

        private bool _AddPerson()
        {          
            this.PersonID = PersonData.AddPerson(this.NationalNO, this.FirstName, this.SecondName,
                this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Phone,
                this.Email, this.NationalityCountryID, this.Imagepath);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
           
            return PersonData.UpdatePerson(this.PersonID, this.NationalNO, this.FirstName, this.SecondName,
                this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Phone,
                this.Email, this.NationalityCountryID, this.Imagepath);
        }

        public bool SavePerson()
        {

            switch (ModePR)
            {
                case enModePerson.AddNew:
                    {
                        if (_AddPerson())
                        {
                            ModePR = enModePerson.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enModePerson.Update:
                    {
                        return _UpdatePerson();
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        static public DataTable ListPeople()
        {

            return PersonData.GetListPeople();
            //try
            //{
            //    DataView data = PersonData.GetListPeople().DefaultView;
            //    return data;
            //}
            //catch
            //{
            //    return null;
            //}
        }

        static public bool DeletePerson(int ID)
        {
            return PersonData.DeletePerson(ID);
        }

        static public bool isPersonExist(int ID)
        {
            return PersonData.IsPersonExist(ID);
        }

        static public bool isNationalIDExist(string NationalNO)
        {
            return PersonData.IsNationalExist(NationalNO);
        }


    }
}
