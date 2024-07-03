using DVLDDataAccessLayer;
using System;

namespace DVLDBussinessLayer
{
    public class clsInternationalInternationalLicense
    {
        private enum enModeInternationalLicense { AddNew = 0, Update = 1 };
        private enModeInternationalLicense ModeInternationalLicense = enModeInternationalLicense.AddNew;

        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public clsApplcation Application;
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public clsLicense License;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser User;

        private clsInternationalInternationalLicense(int internationalLicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID,
            DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;
            ModeInternationalLicense = enModeInternationalLicense.Update;
            Application = clsApplcation.GetApplicationByID(ApplicationID);
            License = clsLicense.FindLicenseByID(IssuedUsingLocalLicenseID);
            User = clsUser.FindUserByID(CreatedByUserID);
        }

        public clsInternationalInternationalLicense()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = false;
            CreatedByUserID = -1;
        }

        public static clsInternationalInternationalLicense FindInternationalLicenseByID(int internationalLicenseID)
        {
            int tmp_ApplicationID = -1, tmp_DriverID = -1, tmp_IssuedUsingLocalLicenseID = -1;
            DateTime tmp_IssueDate = DateTime.Now, tmp_ExpirationDate = DateTime.Now;
            bool tmp_IsActive = false;
            int tmp_CreatedByUserID = -1;
            if (InternationalLicenseData.GetInternationalLicenseByID(internationalLicenseID, ref tmp_IssuedUsingLocalLicenseID, ref tmp_ApplicationID,
                ref tmp_DriverID, ref tmp_IssueDate, ref tmp_ExpirationDate,
                ref tmp_IsActive, ref tmp_CreatedByUserID))
            {
                return new clsInternationalInternationalLicense(internationalLicenseID, tmp_ApplicationID,
                    tmp_DriverID, tmp_IssuedUsingLocalLicenseID, tmp_IssueDate, tmp_ExpirationDate,
                    tmp_IsActive, tmp_CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNew()
        {
            this.InternationalLicenseID = InternationalLicenseData.AddInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
                this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }

        private bool _Update()
        {
            return InternationalLicenseData.UpdateInternationalLicense(this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
                this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
        }

        public bool SaveInternationalLicense()
        {
            switch (ModeInternationalLicense)
            {
                case enModeInternationalLicense.AddNew:
                    {
                        if (_AddNew())
                        {
                            ModeInternationalLicense = enModeInternationalLicense.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enModeInternationalLicense.Update:
                    {
                        return _Update();
                    }
                default:
                    return false;
            }

        }

        static public int CheckInternationalLicenseByLocalID(int LocalLicenseID)
        {
            return InternationalLicenseData.FindInternationalLicenseByLocalID(LocalLicenseID);
        }




    }
}
