using System;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class TestData
    {
        static public bool FindTestByID(int testID, ref string notes, ref bool testResult,
           ref int testAppointmentID, ref int userID)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from Tests where TestID = @testID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@testID;", testID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    if (reader["notes"] != DBNull.Value)
                    {
                        notes = (string)reader["notes"];
                    }
                    else
                    {
                        notes = null;
                    }
                    testResult = (bool)reader["testResult"];
                    testAppointmentID = (int)reader["testAppointmentID"];
                    userID = (int)reader["CreatedByUserID"];

                }
                reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        static public int AddTest(string notes, bool testResult,
            int testAppointmentID, int userID)
        {
            int testID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO [dbo].[Tests]
                           ([TestAppointmentID]
                           ,[TestResult]
           ,                [Notes]
                           ,[CreatedByUserID])
                     VALUES
                           (@testAppointmentID,@testResult,@notes,@userID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);
            command.Parameters.AddWithValue("@testResult", testResult);
            if (notes != null)
            {
                command.Parameters.AddWithValue("@notes", notes);
            }
            else
            {
                command.Parameters.AddWithValue("@notes", DBNull.Value);
            }
            command.Parameters.AddWithValue("@userID", userID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    testID = insertedID;
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return testID;
        }

        static public bool UpdateTest(int testID, string notes, bool testResult,
           int testAppointmentID, int userID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE [dbo].[Tests]
                           SET [TestAppointmentID] = @testAppointmentID
                           ,[TestResult] = @testResult
                           ,[Notes] = @notes
                           ,[CreatedByUserID] = @userID
                           WHERE TestID = @testID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);
            command.Parameters.AddWithValue("@testResult", testResult);
            command.Parameters.AddWithValue("@notes", notes);
            command.Parameters.AddWithValue("@userID", userID);
            command.Parameters.AddWithValue("@testID", testID);
            try
            {
                connection.Open();
                RowAffected = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (testAppointmentID > -1);
        }

        static public int CheckTrialCount(int LocalDrivingLicenseApplicationId, int TestTypeID)
        {
            int Count = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT count(*)
                           FROM Tests INNER JOIN
                        TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
				        where LocalDrivingLicenseApplicationID  = @LocalDrivingLicenseApplicationId and TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationId", LocalDrivingLicenseApplicationId);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    Count = insertedID;
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return Count;

        }

        static public bool CheckPassedTestType(int LocalDrivingLicenseApplicationId, int TestTypeID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT Found = 1
                            FROM Tests INNER JOIN
                           TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
				            where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationId and TestTypeID = @TestTypeID and TestResult = 1;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationId", LocalDrivingLicenseApplicationId);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        static public bool CheckIsAppointmentAttended(int TestAppointmentID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select Found = 1 from Tests where TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        
    }
}
