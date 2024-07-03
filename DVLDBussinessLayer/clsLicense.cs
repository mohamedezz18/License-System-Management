using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLDBussinessLayer.clsLicense;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDBussinessLayer
{
    public class clsLicense
    {
        private enum enModeLicense { AddNew = 0, Update = 1 };
        private enModeLicense ModeLicense = enModeLicense.AddNew;

        public enum enIssueReason {
            FirstTime = 1,
            Renew = 2,
            ReplacementForDamaged = 3,
            ReplacementForLost = 4
        }
        

        public int LicenseID {  get; set; }
        public int ApplicationID { get; set; }
        public clsApplcation Application;

        public int DriverID { get; set; }
        public clsDriver Driver;

        public int LicenseClassID { get; set; }
        public clsLicenseClasses LicenseClasse;
        public  DateTime IssueDate {  get; set; }
        public  DateTime ExpirationDate {  get; set; }
        public string Notes {  get; set; }
        public float PaidFees {  get; set; }

        public bool IsActive {  get; set; }
        public enIssueReason IssueReason = enIssueReason.FirstTime;
        public int CreatedByUserID {  get; set; }
        public clsUser User;

        private clsLicense(int licenseID, int applicationID, int driverID,
            int licenseClassID, DateTime issueDate, DateTime expirationDate,
            string notes, float paidFees, bool isActive, enIssueReason issueReason,
            int createdByUserID)
        {
           LicenseID = licenseID;
           ApplicationID = applicationID;
           DriverID = driverID;
           LicenseClassID = licenseClassID;
           IssueDate = issueDate;
           ExpirationDate = expirationDate;
           Notes = notes;
           PaidFees = paidFees;
           IsActive = isActive;
           IssueReason = issueReason;
           CreatedByUserID = createdByUserID;
           Application = clsApplcation.GetApplicationByID(ApplicationID);
           Driver = clsDriver.FindDriverByID(DriverID);
           LicenseClasse = clsLicenseClasses.FindLicenseClasseByID(LicenseClassID);
           User = clsUser.FindUserByID(CreatedByUserID);
        }
        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = default;
            ExpirationDate = default;
            Notes = "";
            PaidFees = -1;
            IsActive = false;
            IssueReason = default;
            CreatedByUserID = -1;
        }

        static public clsLicense FindLicenseByID(int licenseID)
        {
            int tmp_ApplicationID = -1, tmp_DriverID = -1,
                tmp_LicenseClassID = -1, tmp_CreatedByUserID = -1;
            DateTime tmp_IssueDate =default, tmp_ExpirationDate = default;
            float tmp_PaidFees = -1;
            string tmp_Notes = "";
            bool tmp_IsActive = false;
            byte tmp_IssueReason = default;

            if (LicenseData.GetLicenseByID(licenseID, ref tmp_ApplicationID, ref tmp_DriverID,
                ref tmp_LicenseClassID, ref tmp_IssueDate, ref tmp_ExpirationDate, ref tmp_Notes,
                ref tmp_PaidFees, ref tmp_IsActive, ref tmp_IssueReason, ref tmp_CreatedByUserID))
            {
                return new clsLicense(licenseID, tmp_ApplicationID, tmp_DriverID, tmp_LicenseClassID,
                    tmp_IssueDate, tmp_ExpirationDate, tmp_Notes, tmp_PaidFees, tmp_IsActive,
                    (enIssueReason)tmp_IssueReason, tmp_CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        private bool _AddNewLicense()
        {
           this.LicenseID = LicenseData.AddLicense(this.ApplicationID, this.DriverID,
                this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes,
                this.PaidFees, this.IsActive, Convert.ToByte(this.IssueReason), this.CreatedByUserID);
            return (this.LicenseID  != -1);
        }

        private bool _UpdateLicense()
        {
            return LicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID,
                this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes,
                this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public bool SaveLicense()
        {
            switch (ModeLicense)
            {
                case enModeLicense.AddNew:
                    if (_AddNewLicense())
                    {
                        ModeLicense = enModeLicense.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enModeLicense.Update:
                    return _UpdateLicense();
                default:
                    return false;
            }
        }

        public bool MakeNotActive()
        {
            return LicenseData.MakeLicenseNotActive(this.LicenseID);
        }

    }
}
