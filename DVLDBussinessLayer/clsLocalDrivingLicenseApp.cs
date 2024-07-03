using DVLDDataAccessLayer;
using System.Data;

namespace DVLDBussinessLayer
{
    public class clsLocalDrivingLicenseApp
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode ModeLocalDrivingLicense = enMode.AddNew;

        public int LocalDrivingLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public clsApplcation ApplicationInfo;

        public clsLicenseClasses LicenseClasses;
        private clsLocalDrivingLicenseApp(int localDrivingLicenseID, int applicationID, int licenseClassID)
        {
            LocalDrivingLicenseID = localDrivingLicenseID;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
            ApplicationInfo = clsApplcation.GetApplicationByID(ApplicationID);
            LicenseClasses = clsLicenseClasses.FindLicenseClasseByID(LicenseClassID);
            ModeLocalDrivingLicense = enMode.Update;

        }

        public clsLocalDrivingLicenseApp()
        {

            LocalDrivingLicenseID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
            ModeLocalDrivingLicense = enMode.AddNew;
        }

        public static clsLocalDrivingLicenseApp FindLocalDrivingLicenseByID(int ID)
        {
            int tmp_ApplicationID = -1, tmp_LicenseClassID = -1;

            if (LocalDrivingLicenseAppData.GetLocalDrivingLicenseByID(ID, ref tmp_ApplicationID, ref tmp_LicenseClassID))
            {
                return new clsLocalDrivingLicenseApp(ID, tmp_ApplicationID, tmp_LicenseClassID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNew()
        {
            this.LocalDrivingLicenseID = LocalDrivingLicenseAppData.AddLocalDrivingLicense(this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseID != -1);
        }

        private bool _Update()
        {
            return LocalDrivingLicenseAppData.UpdateLocalDrivingLicenseData(this.LocalDrivingLicenseID, this.ApplicationID, this.LicenseClassID);
        }

        public bool SaveLocalDrivingLicense()
        {
            switch (ModeLocalDrivingLicense)
            {
                case enMode.AddNew:
                    {
                        if (_AddNew())
                        {
                            ModeLocalDrivingLicense = enMode.Update;
                            return true;
                        }
                        else { return false; }
                    }

                case enMode.Update:
                    {
                        return _Update();
                    }
                default:
                    return false;
            }
        }

        static public bool DeleteLocalDrivingApplication(int ApplicationId)
        {
            return LocalDrivingLicenseAppData.DeleteLocalDrivingApp(ApplicationId);
        }

        static public int isPersonUsedForLicenseClass(int Person_ID, int LicenClassId)
        {
            return LocalDrivingLicenseAppData.IsPersonUsedForLicenseClass(Person_ID, LicenClassId);
        }

        static public DataTable GetAllApplicationsForLocalLicense()
        {
            return LocalDrivingLicenseAppData.AllApplicationsForLocalLicense();
        }

        public int PassedTestsCount()
        {
            return LocalDrivingLicenseAppData.GetPassedTestsCount(this.LocalDrivingLicenseID);
        }

        public bool AppointmentIsLocked(int TestTypeID)
        {
            return TestAppointmentData.CheckAppointmentIsLocked(this.LocalDrivingLicenseID, TestTypeID);
        }

        public DataTable ListOfAppointmentForLicenseApplicationID(int TestTypeID)
        {
            return TestAppointmentData.GetListOfAppointmentForApplicationID(this.LocalDrivingLicenseID, TestTypeID);
        }
        public bool HasAttendedSimilarTestBefore(int TestTypeID)
        {
            return TestAppointmentData.CheckAttendedSimilarTestBefore(this.LocalDrivingLicenseID, TestTypeID);
        }

        public bool PassInTestType(int TestTypeID)
        {
            return TestData.CheckPassedTestType(this.LocalDrivingLicenseID, TestTypeID);
        }


        public int GetLicenseId()
        {
            return LocalDrivingLicenseAppData.CheckIsHaveLicense(this.LocalDrivingLicenseID);
        }



    }
}
