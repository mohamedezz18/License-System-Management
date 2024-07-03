using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class PersonData
    {
        static public bool GetPersonByID(int ID, ref string National_NO, ref string Firstname, ref string Secondname,
            ref string Thirdname, ref string Lastname, ref DateTime DateOfbirth, ref byte gender,
            ref string address, ref string phone, ref string email, ref int NationalityCountry_ID, ref string imagepath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from People where PersonID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    National_NO = (string)reader["NationalNo"];
                    Firstname = (string)reader["FirstName"];
                    Secondname = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        Thirdname = (string)reader["ThirdName"];
                    }
                    else
                    {
                        Thirdname = null;
                    }
                    Lastname = (string)reader["LastName"];
                    DateOfbirth = (DateTime)reader["DateOfBirth"];
                    gender = (byte)reader["Gendor"];
                    if (reader["Email"] != DBNull.Value)
                    {
                        address = (string)reader["Address"];
                    }
                    else
                    {
                        address = null;
                    }
                    phone = (string)reader["Phone"];
                    email = (string)reader["Email"];
                    NationalityCountry_ID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        imagepath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        imagepath = null;
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


        static public bool GetPersonByNationalNO(ref int ID, string National_NO, ref string Firstname, ref string Secondname,
           ref string Thirdname, ref string Lastname, ref DateTime DateOfbirth, ref byte gender,
           ref string address, ref string phone, ref string email, ref int NationalityCountry_ID, ref string imagepath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from People where NationalNo = @National_NO;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@National_NO", National_NO);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;

                    ID = (int)reader["PersonID"];
                    Firstname = (string)reader["FirstName"];
                    Secondname = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        Thirdname = (string)reader["ThirdName"];
                    }
                    else
                    {
                        Thirdname = null;
                    }
                    Lastname = (string)reader["LastName"];
                    DateOfbirth = (DateTime)reader["DateOfBirth"];
                    gender = (byte)reader["Gendor"];
                    if (reader["Email"] != DBNull.Value)
                    {
                        address = (string)reader["Address"];
                    }
                    else
                    {
                        address = null;
                    }
                    phone = (string)reader["Phone"];
                    email = (string)reader["Email"];
                    NationalityCountry_ID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        imagepath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        imagepath = null;
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


        static public int AddPerson(string National_NO, string Firstname, string Secondname,
           string Thirdname, string Lastname, DateTime DateOfbirth, byte gender,
           string address, string phone, string email, int NationalityCountry_ID, string imagepath)
        {
            int Person_ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO [dbo].[People]
                           ([NationalNo]
                           ,[FirstName]
                           ,[SecondName]
                           ,[ThirdName]
                           ,[LastName]
                           ,[DateOfBirth]
                           ,[Gendor]
                           ,[Address]
                           ,[Phone]
                           ,[Email]
                           ,[NationalityCountryID]
                           ,[ImagePath])
                           VALUES(@National_NO,@Firstname,@Secondname,@Thirdname,@Lastname,@DateOfbirth,
                            @gender,@address,@phone,@email,@NationalityCountry_ID,@imagepath);
                              SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@National_NO", National_NO);
            command.Parameters.AddWithValue("@Firstname", Firstname);
            command.Parameters.AddWithValue("@Secondname", Secondname);
            command.Parameters.AddWithValue("@Thirdname", Thirdname);
            command.Parameters.AddWithValue("@Lastname", Lastname);
            command.Parameters.AddWithValue("@DateOfbirth", DateOfbirth);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@NationalityCountry_ID", NationalityCountry_ID);
            if (imagepath != "" && imagepath != null)
                command.Parameters.AddWithValue("@imagepath", imagepath);
            else
                command.Parameters.AddWithValue("@imagepath", System.DBNull.Value);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    Person_ID = insertedID;
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return Person_ID;

        }

        static public bool UpdatePerson(int ID,string National_NO, string Firstname, string Secondname,
           string Thirdname, string Lastname, DateTime DateOfbirth, byte gender,
           string address, string phone, string email, int NationalityCountry_ID, string imagepath)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE [dbo].[People]
                            SET [NationalNo] = @National_NO
                               ,[FirstName] = @Firstname
                               ,[SecondName] = @Secondname
                               ,[ThirdName] = @Thirdname
                               ,[LastName] = @Lastname
                               ,[DateOfBirth] = @DateOfbirth
                               ,[Gendor] = @gender
                               ,[Address] =@address
                               ,[Phone] = @phone
                               ,[Email] = @email
                               ,[NationalityCountryID] = @NationalityCountry_ID
                               ,[ImagePath] = @imagepath 
                                where PersonID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@National_NO", National_NO);
            command.Parameters.AddWithValue("@Firstname", Firstname);
            command.Parameters.AddWithValue("@Secondname", Secondname);
            command.Parameters.AddWithValue("@Thirdname", Thirdname);
            command.Parameters.AddWithValue("@Lastname", Lastname);
            command.Parameters.AddWithValue("@DateOfbirth", DateOfbirth);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@NationalityCountry_ID", NationalityCountry_ID);
            if (imagepath != "" && imagepath != null)
                command.Parameters.AddWithValue("@imagepath", imagepath);
            else
                command.Parameters.AddWithValue("@imagepath", System.DBNull.Value);

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


        static public DataTable GetListPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 
                             People.PersonID, 
                             People.NationalNo, 
                             People.FirstName, 
                             People.SecondName, 
                             People.ThirdName, 
                             People.LastName, 
                             CASE 
                                   WHEN People.Gendor = 0 THEN 'Male'
                                   WHEN People.Gendor = 1 THEN 'Female'
                             END AS Gender,
                             Countries.CountryName, 
                             People.DateOfBirth,
                             People.Phone, 
                             People.Email, 
                             People.Address,     
                             People.ImagePath    
                             FROM   
                                  Countries 
                             INNER JOIN
                                  People ON Countries.CountryID = People.NationalityCountryID;
";
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
            string Query = "Delete from People where PersonID = @ID;";
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

        public static bool IsPersonExist(int ID)
        {
            bool isFound = default(bool);

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE PersonID = @ID;";

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
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsNationalExist(string NationalID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE NationalNo = @NationalID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalID", NationalID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch 
            {
                //Console.WriteLine("Error: " + ex.Message);
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

