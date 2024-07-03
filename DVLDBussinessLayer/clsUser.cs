using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsUser : clsPerson
    {
        private enum enModeUser { AddNew = 0, Update = 1 };
        private enModeUser ModeUR = enModeUser.AddNew;

        public int UserID {  get; set; }
        public int Person_ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActived { get; set; }
        private clsPerson _Person;

        public clsPerson Person
        {
            get
            {
                return _Person;
            }
        }

        private clsUser(int userID, int person_ID, string userName, string password, bool isActived)
        {
            UserID = userID;
            Person_ID = person_ID;
            UserName = userName;
            Password = password;
            _Person = clsPerson.FindPersonByID(Person_ID);
            IsActived = isActived;
            ModeUR = enModeUser.Update;
        }

        public clsUser()
        {
            UserID = -1;
            Person_ID = -1;
            UserName = "";
            Password = "";
            IsActived = true;
            ModeUR = enModeUser.AddNew;
        }

        public static clsUser FindUserByID(int ID)
        {
            string tmpUserName = "", tmpPassword = ""; 
            int tmpPersonID = -1;
            bool tmpIsActived = false;

            if (UserData.GetUserByID(ID, ref tmpUserName,ref tmpPassword,ref tmpPersonID,ref tmpIsActived))
            {
                return new clsUser(ID, tmpPersonID, tmpUserName, tmpPassword,tmpIsActived);
            }
            else
            {
                return null;
            }
        }

        public static clsUser FindUserByUsername(string Username)
        {
            string tmpPassword = "";
            int tmpPersonID = -1, tmpUserID = -1;
            bool tmpIsActived = false;

            if (UserData.GetUserByUserName(ref tmpUserID, Username,ref tmpPassword, ref tmpPersonID, ref tmpIsActived))
            {
                return new clsUser(tmpUserID, tmpPersonID, Username, tmpPassword,tmpIsActived);
            }
            else
            {
                return null;
            }

        }

        private bool _AddUser()
        {
            this.UserID = UserData.AddUser(this.UserName,this.Password,this.Person_ID,this.IsActived);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return UserData.UpdateUser(this.UserID, this.UserName,this.Password, this.Person_ID, this.IsActived);
        }

        public bool SaveUser()
        {

            switch (ModeUR)
            {
                case enModeUser.AddNew:
                    {
                        if (_AddUser())
                        {
                            ModeUR = enModeUser.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enModeUser.Update:
                    {
                        return _UpdateUser();
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        static public DataTable GetAllUsers()
        {
            return UserData.GetListUsers();
        }

        static public bool DeleteUser(int ID)
        {
            return UserData.DeletePerson(ID);
        }

        static public bool isUserExist(int Users_ID)
        {
            return UserData.IsUserExist(Users_ID);
        }

        static public bool isPersonUsed(int Person_ID)
        {
            return UserData.IsPersonUsed(Person_ID);
        }
    }
}
