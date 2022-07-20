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
            UserSignUpOut response = new UserSignUpOut();

            var connectionstring = ConfigurationClass.Instance().GetConnectionString("nauticoSportConnectionString");

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("userSignUp", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    string cryp = BCrypt.Net.BCrypt.HashPassword(input.Password, BCrypt.Net.BCrypt.GenerateSalt(13));
                    //cmd.Parameters.Add("@Username", System.Data.SqlDbType.VarChar).Value = input.userName;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            /*var password = reader["Password"].ToString();

                            bool verified = BCrypt.Net.BCrypt.Verify(input.password, password);

                            if (verified)
                            {
                                var user = new User()
                                {
                                    Username = reader["Username"].ToString(),
                                    UserId = int.Parse(reader["Id"].ToString()),
                                    Birthday = DateTime.Parse(reader["Birthday"].ToString()),
                                    CI = int.Parse(reader["CI"].ToString()),
                                    Email = reader["Email"].ToString(),
                                    Genre = (GenreEnum)int.Parse(reader["GenreId"].ToString()),
                                    UserType = (UserTypeEnum)int.Parse(reader["UserTypeId"].ToString()),

                                };

                                response.operationResult = OperationResult.success;
                                response.user = user;
                            }
                            else
                            {
                                response.operationResult = OperationResult.failure;
                            }*/
                        }
                    }
                }
            }

            return response;
        }
    }
}
