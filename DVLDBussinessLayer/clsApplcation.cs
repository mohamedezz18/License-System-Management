using DVLDDataAccessLayer;
using System;
using System.Security.Cryptography.X509Certificates;

namespace DVLDBussinessLayer
{
    public class clsApplcation
    {

        private enum enMode { AddNew = 0, Update = 1 };
        private enMode ModeApplication = enMode.AddNew;
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public enApplicationStatus ApplicationStatus = enApplicationStatus.New;
        public clsApplicationTypes.enApplicationTypes ApplicationTypeMode;
        public int ApplicationID { get; set; }
        public DateTime ApplicationDate { get; set; }

        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }

        public int CreatedByUserID { get; set; }
        public clsUser CurrentUser;

        public int ApplicationTypeID { get; set; }
        public clsApplicationTypes ApplicationType;

        public int ApplicantPersonID { get; set; }
        public clsPerson Person;


        private clsApplcation(int applicationID, int applicantPersonID, DateTime applicationDate,
           enApplicationStatus applicationStatus, int applicationTypeID, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            ApplicationStatus = applicationStatus;
            ApplicationType = clsApplicationTypes.FindApplicationTypeByID(ApplicationTypeID);
            CurrentUser = clsUser.FindUserByID(CreatedByUserID);
            Person = clsPerson.FindPersonByID(ApplicantPersonID);
            ModeApplication = enMode.Update;
        }

        public clsApplcation()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            ApplicationStatus = enApplicationStatus.New;
            ModeApplication = enMode.AddNew;

        }

        static public clsApplcation GetApplicationByID(int Application_ID)
        {
            int tmp_ApplicantPersonID = -1, tmp_CreatedByUserID = -1, tmp_ApplicationTypeID = -1;
            DateTime tmp_LastStatusDate = DateTime.Now, tmp_ApplicationDate = DateTime.Now;
            float tmp_PaidFees = 0;
            byte tmp_Status = 0;
            if (ApplicationData.GetApplicationByID(Application_ID, ref tmp_ApplicantPersonID,
                ref tmp_ApplicationDate, ref tmp_Status, ref tmp_ApplicationTypeID, ref tmp_LastStatusDate,
                ref tmp_PaidFees, ref tmp_CreatedByUserID))
            {
                return new clsApplcation(Application_ID, tmp_ApplicantPersonID,
                    tmp_ApplicationDate, (enApplicationStatus)tmp_Status, tmp_ApplicationTypeID,
                    tmp_LastStatusDate, tmp_PaidFees, tmp_CreatedByUserID);
            }
            else
            {
                return null;
            }
        }


        private bool _UpdateApplicatio()
        {
            return ApplicationData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID,
                this.ApplicationDate, (short)this.ApplicationStatus, this.ApplicationTypeID,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        private bool _AddApplication()
        {
            this.ApplicationID = ApplicationData.AddApplication(this.ApplicantPersonID,
                this.ApplicationDate, (short)this.ApplicationStatus, this.ApplicationTypeID,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);

        }

        public bool SaveApplication()
        {
            switch (ModeApplication)
            {
                case enMode.AddNew:
                    {
                        if (_AddApplication())
                        {
                            ModeApplication = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        return _UpdateApplicatio();
                    }
                default:
                    return false;
            }
        }

        public bool Cancel()
        {
            return ApplicationData.CancelApplication(this.ApplicationID);


        }

        public bool Complete()
        {
            return ApplicationData.CompleteApplication(this.ApplicationID);
        }

        

    }
}
