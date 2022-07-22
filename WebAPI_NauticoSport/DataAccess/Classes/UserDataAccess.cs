using CrossCuttingConcerns.DTOs;
using CrossCuttingConcerns.Enums;
using CrossCuttingConcerns.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    internal class UserDataAccess
    {
        #region singleton
        private static UserDataAccess _instance = new UserDataAccess();

        private UserDataAccess() { }

        public static UserDataAccess Instance()
        {
            return _instance;
        }
        #endregion


        public UserSignUpOut userSignUp(UserSignUpIn input)
        {
            UserSignUpOut response = new UserSignUpOut() {
                Result = OperationResult.failure
            };

            var connectionstring = ConfigurationClass.Instance().GetConnectionString("nauticoSportConnectionString");

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("userSignUp", conn))
                {
                    string passwordHashed = BCrypt.Net.BCrypt.HashPassword(input.Password, BCrypt.Net.BCrypt.GenerateSalt(13));

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Username", System.Data.SqlDbType.VarChar).Value = input.Username;
                    cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = input.Email;
                    cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = input.Name;
                    cmd.Parameters.Add("@Lastname", System.Data.SqlDbType.VarChar).Value = input.Lastname;
                    cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar).Value = passwordHashed;
                    cmd.Parameters.Add("@Ci", System.Data.SqlDbType.VarChar).Value = input.DocumentNumber;
                    cmd.Parameters.Add("@GenreId", System.Data.SqlDbType.Int).Value = (int)input.Genre;
                    cmd.Parameters.Add("@Birthday", System.Data.SqlDbType.DateTime).Value = input.Birthday.ToString("yyyy-MM-dd HH:mm:ss");
                    cmd.Parameters.Add("@RoleId", System.Data.SqlDbType.Int).Value = (int)input.Role;

                    int rowsAffected = cmd.ExecuteNonQuery();

                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        response.Result = OperationResult.success;
                    }

                }
            }

            return response;
        }

        public GetUsersOut getUsers(GetUsersIn input)
        {
            try
            {
                GetUsersOut response = new GetUsersOut() { Result = OperationResult.failure };

                var connectionstring = ConfigurationClass.Instance().GetConnectionString("nauticoSportConnectionString");

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("getUsers", conn))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@PageSize", System.Data.SqlDbType.Int).Value = input.PageSize;
                        cmd.Parameters.Add("@From", System.Data.SqlDbType.Int).Value = input.From;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (response.Users == null)
                            {
                                response.Users = new List<User>();
                            }

                            while (reader.Read())
                            {
                                var user = new User()
                                {
                                    Username = reader["Username"].ToString(),
                                    UserId = int.Parse(reader["Id"].ToString()),
                                    Birthday = DateTime.Parse(reader["Birthday"].ToString()),
                                    Ci = int.Parse(reader["Ci"].ToString()),
                                    Email = reader["Email"].ToString(),
                                    Genre = (GenreEnum)int.Parse(reader["GenreId"].ToString()),
                                    //ProfileIMG = reader["ProfileIMG"].ToString(), TODO - falta crearlo en bd
                                    Role = (RoleEnum)int.Parse(reader["Role"].ToString()),
                                    CreationDate = DateTime.Parse(reader["CreationDate"].ToString()),
                                    Name = reader["Name"].ToString(),
                                    Lastname = reader["Lastname"].ToString(),

                                };

                                response.Users.Add(user);
                            }
                        }
                    }
                    conn.Close();
                }

                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
