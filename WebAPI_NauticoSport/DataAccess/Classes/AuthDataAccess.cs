using CrossCuttingConcerns.DTOs;
using CrossCuttingConcerns.Enums;
using CrossCuttingConcerns.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    internal class AuthDataAccess
    {
        #region singleton
        private static AuthDataAccess _instance = new AuthDataAccess();

        private AuthDataAccess() { }

        public static AuthDataAccess Instance()
        {
            return _instance;
        }
        #endregion


        public LoginOut login(LoginIn input)
        {
            //to get the connection string 
            var connectionstring = ConfigurationClass.Instance().GetConnectionString("nauticoSportConnectionString");
            //build the sqlconnection and execute the sql command
            LoginOut response = new LoginOut() { 
                operationResult = OperationResult.failure
            };
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("userLogin", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Username", System.Data.SqlDbType.VarChar).Value = input.userName;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var password = reader["Password"].ToString();

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
                            }
                        }
                    }
                }
            }
            return response;
        }

        public GetFeaturesByUserOut getFeatureByUser(GetFeaturesByUserIn input)
        {
            //to get the connection string 
            var connectionstring = ConfigurationClass.Instance().GetConnectionString("nauticoSportConnectionString");
            //build the sqlconnection and execute the sql command
            GetFeaturesByUserOut response = new GetFeaturesByUserOut()
            {
                Features = new List<Feature>(),
                operationResult = OperationResult.failure
            };
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("getFeaturesByUser", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Username", System.Data.SqlDbType.VarChar).Value = input.User.Username;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var feature = new Feature()
                            {
                                Id = int.Parse(reader["Id"].ToString()),
                                Name = reader["Name"].ToString(),
                                Enable = int.Parse(reader["Enable"].ToString()),

                            };
                            response.Features.Add(feature);
                        }
                    }
                }
                response.operationResult = OperationResult.success;
            }
            return response;
        }
    }
}
