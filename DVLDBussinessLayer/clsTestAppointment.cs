using DVLDDataAccessLayer;
using System;
using System.Data;

namespace DVLDBussinessLayer
{
    public class clsTestAppointment
    {
        private enum enModeTestAppointmentMode { AddNew = 0, Update = 1 }
        private enModeTestAppointmentMode AppointmentMode = enModeTestAppointmentMode.AddNew;

        public int TestAppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public bool IsLocked { get; set; }

        public int UserID { get; set; }
        public clsUser User;

        public int TestTypeID { get; set; }
        public clsTestTypes TestType;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public clsLocalDrivingLicenseApp LocalDrivingLicenseApplication;

        public int RetakeTestApplicationID { get; set; }
        public clsApplcation RetakeTestApplication;

        private clsTestAppointment(int testAppointmentID, DateTime appointmentDate,
            float paidFees, bool isLocked, int userID, int testTypeID,
            int localDrivingLicenseApplicationID, int retakeTestApplicationID)
        {
            TestAppointmentID = testAppointmentID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            IsLocked = isLocked;
            UserID = userID;
            User = clsUser.FindUserByID(userID);
            TestTypeID = testTypeID;
            TestType = clsTestTypes.FindTestTypeByID(testTypeID);
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            LocalDrivingLicenseApplication = clsLocalDrivingLicenseApp.FindLocalDrivingLicenseByID(localDrivingLicenseApplicationID);
            AppointmentMode = enModeTestAppointmentMode.Update;
            RetakeTestApplicationID = retakeTestApplicationID;
            RetakeTestApplication = clsApplcation.GetApplicationByID(RetakeTestApplicationID);
        }
        public clsTestAppointment()
        {
            TestAppointmentID = -1;
            AppointmentDate = default;
            PaidFees = -1;
            IsLocked = default;
            UserID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentMode = enModeTestAppointmentMode.AddNew;
        }

        static public clsTestAppointment GetTestAppointmentByID(int testAppointmentID)
        {
            int tmp_userID = -1, tmp_testTypeID = 0, tmp_localDrivingLicenseApplicationID = -1,
                tmp_retakeTestApplicationID = -1;
            DateTime tmp_appointmentDate = default;
            float tmp_paidFees = default;
            bool tmp_isLocked = false;

            if (TestAppointmentData.FindTestAppointmentByID(testAppointmentID, ref tmp_appointmentDate, ref tmp_paidFees
                , ref tmp_isLocked, ref tmp_userID, ref tmp_testTypeID, ref tmp_localDrivingLicenseApplicationID, ref tmp_retakeTestApplicationID))
            {
                return new clsTestAppointment(testAppointmentID, tmp_appointmentDate, tmp_paidFees
                , tmp_isLocked, tmp_userID, tmp_testTypeID, tmp_localDrivingLicenseApplicationID, tmp_retakeTestApplicationID);
            }
            else
            {
                return null;
            }

        }

        private bool _AddNew()
        {
            this.TestAppointmentID = TestAppointmentData.AddTestAppointment(this.AppointmentDate,
                this.PaidFees,false, this.UserID, this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.RetakeTestApplicationID);
            return (this.TestAppointmentID != -1);
        }

        private bool _Update()
        {
            return TestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, this.AppointmentDate,
                this.PaidFees, this.IsLocked, this.UserID, this.TestTypeID, this.LocalDrivingLicenseApplicationID,this.RetakeTestApplicationID);
        }

        public bool SaveTestAppointment()
        {
            switch (AppointmentMode)
            {
                case enModeTestAppointmentMode.AddNew:
                    {
                        if (_AddNew())
                        {
                            AppointmentMode = enModeTestAppointmentMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enModeTestAppointmentMode.Update:
                    {
                        return _Update();
                    }
                default:
                    return false;
            }
        }

        public static bool LockedTestAppointment(int TestAppointmentId)
        {
            return TestAppointmentData.LockedThisTestAppointment(TestAppointmentId);
        }

        public static bool IsAppointmentAttended(int TestAppointmentId)
        {
            return TestData.CheckIsAppointmentAttended(TestAppointmentId);
        }






    }
}
