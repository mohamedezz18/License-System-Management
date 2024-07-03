using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class TestAppointmentData
    {
        static public bool FindTestAppointmentByID(int testAppointmentID, ref DateTime appointmentDate,
           ref float paidFees, ref bool isLocked, ref int userID, ref int testTypeID,
           ref int localDrivingLicenseApplicationID, ref int retakeTestApplicationID)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from TestAppointments where TestAppointmentID = @testAppointmentID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    appointmentDate = (DateTime)reader["appointmentDate"];
                    paidFees = Convert.ToSingle(reader["paidFees"]);
                    isLocked = (bool)reader["isLocked"];
                    userID = (int)reader["CreatedByUserID"];
                    testTypeID = (int)reader["testTypeID"];
                    localDrivingLicenseApplicationID = (int)reader["localDrivingLicenseApplicationID"];
                    if (reader["RetakeTestApplicationID"] != DBNull.Value)
                    {
                        retakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                    }
                    else
                    {
                        retakeTestApplicationID = -1;
                    }
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

        static public int AddTestAppointment(DateTime appointmentDate,
            float paidFees, bool isLocked, int userID, int testTypeID,
            int localDrivingLicenseApplicationID, int retakeTestApplicationID)
        {
            int testAppointmentID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO [dbo].[TestAppointments]
                             ([TestTypeID]
                             ,[LocalDrivingLicenseApplicationID]
                             ,[AppointmentDate]
                             ,[PaidFees]
                             ,[CreatedByUserID]
                             ,[IsLocked]
                             ,[RetakeTestApplicationID])
                       VALUES
                             (@testTypeID,@localDrivingLicenseApplicationID,@appointmentDate,
                              @paidFees,@userID,@isLocked,@retakeTestApplicationID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@testTypeID", testTypeID);
            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@appointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@paidFees", paidFees);
            command.Parameters.AddWithValue("@isLocked", isLocked);
            command.Parameters.AddWithValue("@userID", userID);
            if (retakeTestApplicationID != -1)
                command.Parameters.AddWithValue("@retakeTestApplicationID", retakeTestApplicationID);
            else
                command.Parameters.AddWithValue("@retakeTestApplicationID", System.DBNull.Value);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    testAppointmentID = insertedID;
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return testAppointmentID;
        }

        static public bool UpdateTestAppointment(int testAppointmentID, DateTime appointmentDate,
            float paidFees, bool isLocked, int userID, int testTypeID,
            int localDrivingLicenseApplicationID, int retakeTestApplicationID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE [dbo].[TestAppointments]
                            SET [TestTypeID] = @testTypeID
                           ,[LocalDrivingLicenseApplicationID] = @localDrivingLicenseApplicationID
                           ,[AppointmentDate] = @appointmentDate
                           ,[PaidFees] = @paidFees
                           ,[CreatedByUserID] = @userID
                           ,[IsLocked] = @isLocked
                           ,[RetakeTestApplicationID] = @retakeTestApplicationID
                           where TestAppointmentID = @testAppointmentID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@testTypeID", testTypeID);
            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@appointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@paidFees", paidFees);
            command.Parameters.AddWithValue("@isLocked", isLocked);
            command.Parameters.AddWithValue("@userID", userID);
            command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);
            if (retakeTestApplicationID != -1)
                command.Parameters.AddWithValue("@retakeTestApplicationID", retakeTestApplicationID);
            else
                command.Parameters.AddWithValue("@retakeTestApplicationID", System.DBNull.Value);
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
            return (RowAffected > 0);
        }

        static public bool CheckAppointmentIsLocked(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select Distinct Found = 1 from TestAppointments
                           where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                            and IsLocked = 0 and TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch
            {

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }

        static public DataTable GetListOfAppointmentForApplicationID(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select TestAppointments.TestAppointmentID, TestAppointments.AppointmentDate,
                              TestAppointments.PaidFees,TestAppointments.IsLocked
                              from TestAppointments 
                              where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestTypeID = @TestTypeID
                               order by TestAppointmentID desc;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }

        static public bool CheckAttendedSimilarTestBefore(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT *
                            FROM Tests INNER JOIN
                  TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
				  where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestTypeID =@TestTypeID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
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

        static public bool LockedThisTestAppointment(int TestAppointmentID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE [dbo].[TestAppointments]
                           SET [IsLocked] = 1
                           WHERE TestAppointmentID = @TestAppointmentID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
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
            return (RowAffected > 0);
        }
    }

}
