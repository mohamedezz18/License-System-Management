using System;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class LicenseData
    {
        static public bool GetLicenseByID(int licenseID, ref int applicationID, ref int driverID,
           ref int licenseClassID, ref DateTime issueDate, ref DateTime expirationDate,
           ref string notes, ref float paidFees, ref bool isActive, ref byte issueReason,
           ref int createdByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from Licenses where LicenseID = @licenseID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@licenseID", licenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    licenseClassID = (int)reader["LicenseClassID"];
                    issueDate = (DateTime)reader["IssueDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] != DBNull.Value)
                    {
                        notes = (string)reader["Notes"];
                    }
                    else
                    {
                        notes = null;
                    }
                    paidFees = Convert.ToByte(reader["PaidFees"]);
                    isActive = (bool)reader["IsActive"];
                    issueReason = (byte)reader["IssueReason"];
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


        static public int AddLicense(int applicationID, int driverID,
            int licenseClassID, DateTime issueDate, DateTime expirationDate,
            string notes, float paidFees, bool isActive, byte issueReason,
            int createdByUserID)
        {
            int License_ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO [dbo].[Licenses]
           ([ApplicationID]
           ,[DriverID]
           ,[LicenseClassID]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[Notes]
           ,[PaidFees]
           ,[IsActive]
           ,[IssueReason]
           ,[CreatedByUserID])
     VALUES
           (@applicationID,@driverID,@licenseClassID,@issueDate,@expirationDate,@notes
		   ,@paidFees,@isActive,@issueReason,@createdByUserID);
		                    SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@applicationID", applicationID);
            command.Parameters.AddWithValue("@driverID", driverID);
            command.Parameters.AddWithValue("@licenseClassID", licenseClassID);
            command.Parameters.AddWithValue("@issueDate", issueDate);
            command.Parameters.AddWithValue("@expirationDate", expirationDate);
            if (notes != null)
            {
                command.Parameters.AddWithValue("@notes", notes);
            }
            else
            {
                command.Parameters.AddWithValue("@notes", DBNull.Value);
            }
            command.Parameters.AddWithValue("@paidFees", paidFees);
            command.Parameters.AddWithValue("@isActive", isActive);
            command.Parameters.AddWithValue("@issueReason", issueReason);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    License_ID = insertedID;
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return License_ID;

        }

        static public bool UpdateLicense(int licenseID, int applicationID, int driverID,
           int licenseClassID, DateTime issueDate, DateTime expirationDate,
           string notes, float paidFees, bool isActive, byte issueReason,
           int createdByUserID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE [dbo].[Licenses]
                            SET [ApplicationID] = @applicationID
                               ,[DriverID] = @driverID
                               ,[LicenseClassID] = @licenseClassID
                               ,[IssueDate] = @issueDate
                               ,[ExpirationDate] = @expirationDate
                               ,[Notes] = @notes
                               ,[PaidFees] = @paidFees
                               ,[IsActive] = @isActive
                               ,[IssueReason] = @issueReason
                               ,[CreatedByUserID] = @createdByUserID
                          WHERE LicenseID = @licenseID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@applicationID", applicationID);
            command.Parameters.AddWithValue("@driverID", driverID);
            command.Parameters.AddWithValue("@licenseClassID", licenseClassID);
            command.Parameters.AddWithValue("@issueDate", issueDate);
            command.Parameters.AddWithValue("@expirationDate", expirationDate);
            command.Parameters.AddWithValue("@notes", notes);
            command.Parameters.AddWithValue("@paidFees", paidFees);
            command.Parameters.AddWithValue("@isActive", isActive);
            command.Parameters.AddWithValue("@issueReason", issueReason);
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

        public static bool MakeLicenseNotActive(int licenseID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE [dbo].[Licenses]
                            SET [IsActive] = 0
                          WHERE LicenseID = @licenseID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@licenseID", licenseID);
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
