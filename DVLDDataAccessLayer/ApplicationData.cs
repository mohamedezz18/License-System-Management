using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDDataAccessLayer
{
    public class ApplicationData
    {
        static public bool GetApplicationByID(int applicationID,ref int applicantPersonID, ref DateTime applicationDate,
           ref byte applicationStatus, ref int applicationTypeID, ref DateTime lastStatusDate, ref float paidFees, ref int createdByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from Applications where ApplicationID = @applicationID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@applicationID", applicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    applicantPersonID = (int)reader["ApplicantPersonID"];
                    applicationStatus = Convert.ToByte(reader["ApplicationStatus"]);
                    applicationTypeID = (int)reader["ApplicationTypeID"];
                    applicationDate = (DateTime)reader["ApplicationDate"];
                    lastStatusDate = (DateTime)reader["LastStatusDate"];
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    createdByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch
            {
                IsFound =false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }


        static public bool UpdateApplication(int applicationID, int applicantPersonID, DateTime applicationDate,
            short applicationStatus,int applicationTypeID, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE [dbo].[Applications]
                            SET [ApplicantPersonID] = @applicantPersonID
                               ,[ApplicationDate] = @applicationDate
                               ,[ApplicationTypeID] = @applicationTypeID
                               ,[ApplicationStatus] = @applicationStatus
                               ,[LastStatusDate] = @lastStatusDate
                               ,[PaidFees] = @paidFees
                               ,[CreatedByUserID] = @createdByUserID
                          WHERE ApplicationID = @applicationID;";
            SqlCommand command =new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@applicantPersonID", applicantPersonID);
            command.Parameters.AddWithValue("@applicationDate", applicationDate);
            command.Parameters.AddWithValue("@applicationTypeID", applicationTypeID);
            command.Parameters.AddWithValue("@applicationStatus", applicationStatus);
            command.Parameters.AddWithValue("@lastStatusDate", lastStatusDate);
            command.Parameters.AddWithValue("@paidFees", paidFees);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            command.Parameters.AddWithValue("@applicationID", applicationID);
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
                connection.Close( );
            }
            return ( RowAffected > 0 );

        }

        static public int AddApplication(int applicantPersonID, DateTime applicationDate,
            short applicationStatus, int applicationTypeID, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            int Application_ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO [dbo].[Applications]
                             ([ApplicantPersonID]
                            ,[ApplicationDate]
                            ,[ApplicationTypeID]
                            ,[ApplicationStatus]
                            ,[LastStatusDate]
                            ,[PaidFees]
                            ,[CreatedByUserID])
                      VALUES
                            (@applicantPersonID
                            ,@applicationDate
                            ,@applicationTypeID
                            ,@applicationStatus
                            ,@lastStatusDate
                            ,@paidFees
                            ,@createdByUserID);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@applicantPersonID", applicantPersonID);
            command.Parameters.AddWithValue("@applicationDate", applicationDate);
            command.Parameters.AddWithValue("@applicationTypeID", applicationTypeID);
            command.Parameters.AddWithValue("@applicationStatus", applicationStatus);
            command.Parameters.AddWithValue("@lastStatusDate", lastStatusDate);
            command.Parameters.AddWithValue("@paidFees", paidFees);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    Application_ID = insertedID;
                }
            }
            catch
            {  
            }
            finally 
            {
                connection.Close();
            }
            return Application_ID;

        }

        static public bool CancelApplication(int ApplicationId)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE [dbo].[Applications]
                             SET [ApplicationStatus] = 2
                             ,LastStatusDate = GETDATE()
                           WHERE ApplicationID = @ApplicationId;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationId", ApplicationId);

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

        static public bool CompleteApplication(int ApplicationId)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE [dbo].[Applications]
                             SET [ApplicationStatus] = 3
                             ,LastStatusDate = GETDATE()
                           WHERE ApplicationID = @ApplicationId;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationId", ApplicationId);
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
