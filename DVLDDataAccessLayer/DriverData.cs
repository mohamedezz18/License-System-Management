using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class DriverData
    {
        static public bool GerDriverByID(int driverID, ref int PersonID, ref int createdByUserID, ref DateTime createdDate)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from Drivers where DriverID = @driverID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@driverID", driverID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                    createdDate = (DateTime)reader["CreatedDate"];
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

        static public bool GerDriverByPersonID(ref int driverID, int PersonId, ref int createdByUserID, ref DateTime createdDate)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from Drivers where PersonID = @PersonId;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonId", PersonId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    driverID = (int)reader["driverID"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                    createdDate = (DateTime)reader["CreatedDate"];
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

        static public int AddDriver(int PersonID, int createdByUserID, DateTime createdDate)
        {
            int Driver_ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO [dbo].[Drivers]
                            ([PersonID]
                            ,[CreatedByUserID]
                            ,[CreatedDate])
                      VALUES
                            (@PersonID,@createdByUserID,@createdDate);
		                    SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            command.Parameters.AddWithValue("@createdDate", createdDate);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    Driver_ID = insertedID;
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return Driver_ID;

        }

        static public bool UpdateDriver(int driverID , int PersonID, int createdByUserID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE [dbo].[Drivers]
                           SET [PersonID] = @PersonID
                              ,[CreatedByUserID] = @createdByUserID
                           WHERE DriverID = @driverID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
          //  command.Parameters.AddWithValue("@createdDate", createdDate);
            command.Parameters.AddWithValue("@driverID", driverID);

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

        static public DataTable GetListDrivers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from Drivers_View;";
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

        static public DataTable GetListLocalLicense(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from Licenses where DriverID = @DriverID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
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

        static public DataTable GetListInternationalLicense(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from InternationalLicenses where DriverID = @DriverID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
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

        static public int IfDriverHaveActiveThisLicenseClass(int DriverID, int LicenseClassID)
        {
            int licenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT LicenseID
                            FROM Licenses
				            where DriverID = @DriverID and IsActive = 1 and LicenseClassID = @LicenseClassID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    licenseID = insertedID;
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return licenseID;
        }
    }
}
