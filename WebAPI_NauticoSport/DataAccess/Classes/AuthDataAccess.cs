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
                Features = new List<Feature>(),
                Result = OperationResult.failure
            };
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("userLogin", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Username", System.Data.SqlDbType.VarChar).Value = input.Username;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                            while (reader.Read())
                            {
                                var password = reader["Password"].ToString();

                                bool verified = BCrypt.Net.BCrypt.Verify(input.Password, password);

                                if (verified)
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
                                            LastName = reader["Lastname"].ToString(),

                                        };
                                            response.User = user;

                                    reader.NextResult();

                                    while (reader.Read())
                                    {

                                        response.Features.Add(
                                        new Feature()
                                        {
                                            Id = int.Parse(reader["FeatureId"].ToString()),
                                            Name = reader["FeatureName"].ToString(),
                                            Description = reader["FeatureDescription"].ToString()
                                        }
                                        );
                                    }



                                    response.Result = OperationResult.success;
                                }
                                else
                                {
                                    response.Result = OperationResult.failure;
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
                                Description = reader["Description"].ToString(),

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
