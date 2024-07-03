using DVLDDataAccessLayer;
using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace DVLDBussinessLayer
{
    public class clsDriver
    {
        public enum enModeDriver { AddNew = 0, Update = 1 };
        public enModeDriver ModeDriver = enModeDriver.AddNew;

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public clsPerson Person;
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        private clsDriver(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
            Person = clsPerson.FindPersonByID(PersonID);
            ModeDriver = enModeDriver.Update;
        }
        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
        }

        public static clsDriver FindDriverByID(int driverID)
        {
            int tmp_PersonID = -1, tmp_CreatedByUserID = -1;
            DateTime tmp_CreatedDate = default;

            if (DriverData.GerDriverByID(driverID, ref tmp_PersonID, ref tmp_CreatedByUserID, ref tmp_CreatedDate))
            {
                return new clsDriver(driverID, tmp_PersonID, tmp_CreatedByUserID, tmp_CreatedDate);
            }
            else
            {
                return null;
            }

        }

        public static clsDriver FindDriverByPersonID(int PersonId)
        {
            int tmp_driverID = -1, tmp_CreatedByUserID = -1;
            DateTime tmp_CreatedDate = default;

            if (DriverData.GerDriverByPersonID(ref tmp_driverID, PersonId, ref tmp_CreatedByUserID, ref tmp_CreatedDate))
            {
                return new clsDriver(tmp_driverID, PersonId, tmp_CreatedByUserID, tmp_CreatedDate);
            }
            else
            {
                return null;
            }

        }

        private bool _AddNew()
        {
            this.DriverID = DriverData.AddDriver(this.PersonID, this.CreatedByUserID, DateTime.Now);
            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            return DriverData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID);
        }

        public bool SaveDriver()
        {
            switch (ModeDriver)
            {
                case enModeDriver.AddNew:
                    {
                        if (_AddNew())
                        {
                            ModeDriver = enModeDriver.Update;
                            return true;
                        }
                        else { return false; }
                    }
                case enModeDriver.Update:
                    {
                        return _UpdateDriver();

                    }
                default:
                    {
                        return false;
                    }
            }
        }


        public static DataTable GetAllDrivers()
        {
            return DriverData.GetListDrivers();
        }

        public DataTable GetLocalLicenseHistory()
        {
            return DriverData.GetListLocalLicense(this.DriverID);
        }

        public DataTable GetInternationalLicenseHistory()
        {
            return DriverData.GetListInternationalLicense(this.DriverID);
        }
        public int IsDriverHaveActiveThisLicenseClass(int LicenseClassID)
        {
            return DriverData.IfDriverHaveActiveThisLicenseClass(this.DriverID, LicenseClassID);
        }
    }
}
