using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsTest
    {
        private enum enModeTestMode { AddNew = 0, Update = 1 }
        private enModeTestMode TestMode = enModeTestMode.AddNew;

        public int TestID { get; set; }
        public string Notes { get; set; }
        public bool TestResult { get; set; }

        public int TestAppointmentID { get; set; }
        public clsTestAppointment testAppointment;

        public int UserID { get; set; }
        public clsUser User;

        private clsTest(int testID, string notes, bool testResult, int testAppointmentID, int userID)
        {
            TestID = testID;
            Notes = notes;
            TestAppointmentID = testAppointmentID;
            UserID = userID;
            testAppointment = clsTestAppointment.GetTestAppointmentByID(testAppointmentID);
            User = clsUser.FindUserByID(userID);
            TestMode = enModeTestMode.Update;
        }

        public clsTest()
        {
            TestID = -1;
            Notes = default;
            TestAppointmentID = -1;
            UserID = -1;
            TestMode = enModeTestMode.AddNew;
        }

        static public clsTest GetTestByID(int testID)
        {
            int tmp_testAppointmentID = default, tmp_userID = default;
            string tmp_notes = default;
            bool tmp_testResult = default;

            if (TestData.FindTestByID(testID, ref tmp_notes, ref tmp_testResult,
                ref tmp_testAppointmentID, ref tmp_userID))
            {
                return new clsTest(testID, tmp_notes, tmp_testResult, tmp_testAppointmentID, tmp_userID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNew()
        {
            this.TestID = TestData.AddTest(this.Notes, this.TestResult, this.TestAppointmentID, this.UserID);
            return (TestID != -1);

        }

        private bool _Update()
        {
            return TestData.UpdateTest(this.TestID, this.Notes, this.TestResult, this.TestAppointmentID, this.UserID);
        }

        public bool SaveTest()
        {
            switch (TestMode)
            {
                case enModeTestMode.AddNew:
                    {
                        if (_AddNew())
                        {
                            TestMode = enModeTestMode.AddNew;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enModeTestMode.Update:
                    {
                        return _Update();
                    }
                default:
                    return false;
            }
        }

        static public int GetTrial(int LocalDrivingLicenseApplicationId,int TestTypeID)
        {
            return TestData.CheckTrialCount(LocalDrivingLicenseApplicationId, TestTypeID);
        }

        

    }
}
