using System;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class InternationalLicenseData
    {
        static public bool GetInternationalLicenseByID(int internationalLicenseID, ref int issuedUsingLocalLicenseID, ref int applicationID, ref int driverID,
            ref DateTime issueDate, ref DateTime expirationDate,
            ref bool isActive, ref int createdByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from InternationalLicenses where InternationalLicenseID = @internationalLicenseID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@internationalLicenseID", internationalLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    issuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    issueDate = (DateTime)reader["IssueDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    isActive = (bool)reader["IsActive"];
                    createdByUserID = (int)reader["CreatedByUserID"];
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

        static public int AddInternationalLicense(int applicationID, int driverID,
        int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate,
        bool isActive, int createdByUserID)
        {
            int InternationalLicense_ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO [dbo].[InternationalLicenses]
           ([ApplicationID]
           ,[DriverID]
           ,[IssuedUsingLocalLicenseID]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[IsActive]
           ,[CreatedByUserID])
           VALUES
            (@applicationID,@driverID,@issuedUsingLocalLicenseID,@issueDate,@expirationDate,
            @isActive,@createdByUserID);
                   SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@applicationID", applicationID);
            command.Parameters.AddWithValue("@driverID", driverID);
            command.Parameters.AddWithValue("@issuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@issueDate", issueDate);
            command.Parameters.AddWithValue("@expirationDate", expirationDate);
            command.Parameters.AddWithValue("@isActive", isActive);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    InternationalLicense_ID = insertedID;
                }
            }
            catch
            {
                // Handle exceptions as needed
            }
            finally
            {
                connection.Close();
            }
            return InternationalLicense_ID;
        }

        static public bool UpdateInternationalLicense(int internationalLicenseID, int applicationID, int driverID,
        int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate,
        bool isActive, int createdByUserID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE [dbo].[Licenses]
                      SET [ApplicationID] = @applicationID
                       ,[DriverID] = @driverID
                       ,[IssuedUsingLocalLicenseID] = @issuedUsingLocalLicenseID
                       ,[IssueDate] = @issueDate
                       ,[ExpirationDate] = @expirationDate
                       ,[IsActive] = @isActive
                       ,[CreatedByUserID] = @createdByUserID
                  WHERE InternationalLicenseID = @internationalLicenseID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@internationalLicenseID", internationalLicenseID);
            command.Parameters.AddWithValue("@applicationID", applicationID);
            command.Parameters.AddWithValue("@driverID", driverID);
            command.Parameters.AddWithValue("@issuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@issueDate", issueDate);
            command.Parameters.AddWithValue("@expirationDate", expirationDate);
            command.Parameters.AddWithValue("@isActive", isActive);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

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

        static public int FindInternationalLicenseByLocalID(int LocalLicenseID)
        {
            int InternationalLicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select InternationalLicenseID from InternationalLicenses where IssuedUsingLocalLicenseID = @LocalLicenseID and IsActive = 1;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    InternationalLicenseID = insertedID;
                }
            }
            catch
            {
                
            }
            finally
            {
                connection.Close();
            }
            return InternationalLicenseID;
        }


    }

}
