using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class TestTypesData
    {
        static public bool GetTestTypeByID(int ID, ref string TestTypeTitle,ref string TestTypeDescription, ref float TestTypeFees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from TestTypes where TestTypeID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFees = Convert.ToSingle(reader["TestTypeFees"]);
                   
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

        static public bool UpdateTestType(int ID, string TestType_Title, string TestType_Description, float TestType_Fees)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE [dbo].[TestTypes]
                              SET [TestTypeTitle] = @TestType_Title
                              ,[TestTypeDescription] = @TestType_Description
                              ,[TestTypeFees] = @TestType_Fees
                               WHERE TestTypeID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@TestType_Title", TestType_Title);
            command.Parameters.AddWithValue("@TestType_Fees", TestType_Fees);
            command.Parameters.AddWithValue("@TestType_Description", TestType_Description);
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

        static public DataTable AllTestTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from TestTypes;";
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
    }
}
