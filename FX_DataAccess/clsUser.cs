using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_DataAccess
{
    public class clsUserData
    {
            public static bool GetUserByUserId(int UserId, ref string Username, ref string Password, ref byte Role, ref byte IsActive)
            {
                bool IsFound = false;
                try
                {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                        string query = @"select * from Users Where UserId=@UserId";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserId", UserId);

                            connection.Open();

                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                IsFound = true;
                                Username = (string)reader["Username"];
                                Password = (string)reader["Password"];
                                Role = Convert.ToByte(reader["Role"]);
                                IsActive = Convert.ToByte(reader["IsActive"]);
                            }
                            else
                            {
                                IsFound = false;
                            }
                            reader.Close();

                        }
                    }
                }

                catch (Exception ex)
                {
                    clsEventLog.LogOrCreateEventSoures(ex.Message);
                }

                return IsFound;
            }

            public static bool GetUserInfoByUsernameAndPassword(string UserName, string Password, ref int UserId, ref byte Role, ref byte IsActive)
            {
                bool IsFound = false;
                try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                        string query = @"SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserName", UserName);
                            command.Parameters.AddWithValue("@Password", Password);

                            connection.Open();

                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                IsFound = true;
                                UserId = (int)reader["UserId"];
                                UserName = (string)reader["Username"];
                                Password = (string)reader["Password"];
                                Role = Convert.ToByte(reader["Role"]);
                                IsActive = Convert.ToByte(reader["IsActive"]);
                            }
                            else
                            {
                                IsFound = false;
                            }
                            reader.Close();

                        }
                    }
                }

                catch (Exception ex)
                {
                    clsEventLog.LogOrCreateEventSoures(ex.Message);
                }

                return IsFound;
            }
        public static DataTable GetAllUsers()
        {
            DataTable _dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string Query = @"Select  UserId,Username,Role,IsActive from Users";
                SqlCommand command = new SqlCommand(Query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        _dt.Load(reader);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    clsEventLog.LogOrCreateEventSoures(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return _dt;
            }
        }

        public static bool IsUserExist(string UserName, string Password)
        {
            ;
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {

                string query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    IsFound = reader.HasRows;


                }
                catch (Exception ex)
                {
                    clsEventLog.LogOrCreateEventSoures(ex.Message);
                    IsFound = false;
                }
                finally
                {
                    connection.Close();
                }
                return IsFound;
            }
        }

            public static int AddNewUsers(string Username, string Password, byte Role, byte IsActive)
            {
                int UserId = -1;
                try
                {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                { 
                    string query = @"insert into Users (Username,Password,Role, IsActive) Values (@Username,@Password,@Role, @IsActive)
                                      select SCOPE_IDENTITY()";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Username", Username);
                            command.Parameters.AddWithValue("@Password", Password);
                            command.Parameters.AddWithValue("@Role", Role);
                            command.Parameters.AddWithValue("@IsActive", IsActive);

                            connection.Open();
                            object Result = command.ExecuteScalar();

                            if (Result != null && int.TryParse(Result.ToString(), out int InsertId))
                            {
                                UserId = InsertId;
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    clsEventLog.LogOrCreateEventSoures(ex.Message);
                }

                return UserId;
            }

            public static bool UpdateUsers(int UserId, string Username, string Password, byte Role, byte IsActive)
            {
                int rowAffected = 0;

                try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                        string query = @"
                                   update Users set Username=@Username,
                                   Password=@Password,
                                   Role=@Role,
                                   IsActive=@IsActive
                                   where UserId=@UserId";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserId", UserId);
                            command.Parameters.AddWithValue("@Username", Username);
                            command.Parameters.AddWithValue("@Password", Password);
                            command.Parameters.AddWithValue("@Role", Role);
                            command.Parameters.AddWithValue("@IsActive", IsActive);

                            connection.Open();

                            rowAffected = command.ExecuteNonQuery();


                        }
                    }
                }

                catch (Exception ex)
                {
                    clsEventLog.LogOrCreateEventSoures(ex.Message);
                }

                return (rowAffected > 0);
            }

        public static bool IsUserExist(string UserName)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {

                string query = "select Found=1 from  Users where UserName=@UserName";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UserName", UserName);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    IsFound = reader.HasRows;


                }
                catch (Exception ex)
                {
                    clsEventLog.LogOrCreateEventSoures(ex.Message);
                    IsFound = false;
                }
                finally
                {
                    connection.Close();
                }
                return IsFound;
            }
        }
            public static bool DeleteUsers(int UserId)
            {
                int rowAffected = 0;

                try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                        string query = @"Delete  from Users Where UserId=@UserId";


                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserId", UserId);

                            connection.Open();

                            rowAffected = command.ExecuteNonQuery();

                        }
                    }
                }

                catch (Exception ex)
                {
                    clsEventLog.LogOrCreateEventSoures(ex.Message);
                }
                return (rowAffected > 0);

            }
        }
    }
 