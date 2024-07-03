using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class UserData
    {
        static public bool GetUserByID(int ID,ref string UserName,ref string Password,ref int PersonID, ref bool IsActived)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from Users where UserID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    PersonID = (int)reader["PersonID"];
                    IsActived = (bool)reader["IsActive"];
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

        static public bool GetUserByUserName(ref int UserID, string UserName,ref string Password, ref int PersonID, ref bool IsActived)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from Users where UserName =@UserName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
        
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    UserID = (int)reader["UserID"];
                    IsActived = (bool)reader["IsActive"];
                    Password= (string)reader["Password"];
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

        static public int AddUser(string UserName,string Password,int PersonID,bool IsActived)
        {
            int User_ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO [dbo].[Users]
                            ([PersonID]
                            ,[UserName]
                            ,[Password]
                            ,[IsActive])
                      VALUES
                            (@PesonID, @UserName, @Password, @IsActive);
                              SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PesonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActived);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    User_ID = insertedID;
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return User_ID;

        }

        static public bool UpdateUser(int ID,string UserName,string Password,int PersonID,bool IsActived)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE [dbo].[Users]
                            SET [PersonID] = @PersonID
                               ,[UserName] = @UserName
                               ,[Password] = @Password
                               ,[IsActive] = @IsActive
                                where UserID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActived);

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

        static public DataTable GetListUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Users.UserID, Users.PersonID,FullName = People.FirstName +' '+ People.SecondName  +' '+  People.ThirdName  +' '+
                             People.LastName ,Users.UserName,Users.Password,Users.IsActive
                             FROM   People INNER JOIN
                             Users ON People.PersonID = Users.PersonID;";
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

        static public bool DeletePerson(int ID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Delete from Users where UserID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
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

        public static bool IsUserExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

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

        public static bool IsPersonUsed(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE PersonID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

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
    }
}
