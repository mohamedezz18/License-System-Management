using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDDataAccessLayer
{
    public class LocalDrivingLicenseAppData
    {
        static public bool GetLocalDrivingLicenseByID(int localDrivingLicenseID, ref int applicationID, ref int licenseClassID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @localDrivingLicenseID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@localDrivingLicenseID", localDrivingLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    applicationID = (int)reader["ApplicationID"];
                    licenseClassID = (int)reader["LicenseClassID"];
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

        static public int AddLocalDrivingLicense(int applicationID, int licenseClassID)
        {
            int localDrivingLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO [dbo].[LocalDrivingLicenseApplications]
                           ([ApplicationID]
                           ,[LicenseClassID])
                        VALUES
                           (@applicationID , @licenseClassID);
                         SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@applicationID", applicationID);
            command.Parameters.AddWithValue("@licenseClassID", licenseClassID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    localDrivingLicenseID = insertedID;
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return localDrivingLicenseID;
        }

        static public bool UpdateLocalDrivingLicenseData(int localDrivingLicenseID, int applicationID, int licenseClassID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE [dbo].[LocalDrivingLicenseApplications]
                           SET [ApplicationID] = @applicationID
                              ,[LicenseClassID] = @licenseClassID
                           WHERE LocalDrivingLicenseApplicationID  = @localDrivingLicenseID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@applicationID", applicationID);
            command.Parameters.AddWithValue("@licenseClassID", licenseClassID);
            command.Parameters.AddWithValue("@localDrivingLicenseID", localDrivingLicenseID);
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

        public static int IsPersonUsedForLicenseClass(int Person_ID, int LicenseClassId)
        {
            int _ApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT LocalDrivingLicenseApplications.ApplicationID
             FROM   LocalDrivingLicenseApplications INNER JOIN
             Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN
             LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
			 where Applications.ApplicantPersonID = @Person_ID and LocalDrivingLicenseApplications.LicenseClassID= @LicenseClassId
             and Applications.ApplicationStatus != 2;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Person_ID", Person_ID);
            command.Parameters.AddWithValue("@LicenseClassId", LicenseClassId);
            try
            {

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    _ApplicationID = insertedID;
                }

            }
            catch
            {


            }
            finally
            {
                connection.Close();
            }

            return _ApplicationID;
        }

        static public bool DeleteLocalDrivingApp(int ApplicationID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Delete from LocalDrivingLicenseApplications 
	                        where ApplicationID = @ApplicationID;
                            DELETE FROM [dbo].[Applications]
                            WHERE ApplicationID =@ApplicationID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
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

        static public DataTable AllApplicationsForLocalLicense()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View;";
            SqlCommand command = new SqlCommand(query, connection);
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

        static public int GetPassedTestsCount(int localDrivingLicenseID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select PassedTestCount from LocalDrivingLicenseApplications_View 
                               where LocalDrivingLicenseApplicationID = @localDrivingLicenseID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@localDrivingLicenseID", localDrivingLicenseID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    localDrivingLicenseID = insertedID;
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return localDrivingLicenseID;
        }

        static public int CheckIsHaveLicense(int LocalDrivingLicenseID)
        {
            int LicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT LicenseID
                        FROM  LocalDrivingLicenseApplications INNER JOIN
                  Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN
                  Licenses ON Applications.ApplicationID = Licenses.ApplicationID
				  where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseID", LocalDrivingLicenseID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return LicenseID;
        }
    }
}
