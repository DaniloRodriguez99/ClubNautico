using CrossCuttingConcerns.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    internal class PartnerDataAccess
    {
        #region singleton
        private static PartnerDataAccess _instance = new PartnerDataAccess();

        private PartnerDataAccess() { }

        public static PartnerDataAccess Instance()
        {
            return _instance;
        }
        #endregion

        /*public PartnerSignUpOut partnerSignUp(PartnerSignUpIn input) {
            PartnerSignUpOut response = new PartnerSignUpOut();

            var connectionstring = ConfigurationClass.Instance().GetConnectionString("nauticoSportConnectionString");

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("partnerSignUp", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //cmd.Parameters.Add("@Username", System.Data.SqlDbType.VarChar).Value = input.userName;

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


            string cryp = BCrypt.Net.BCrypt.HashPassword(input.password, BCrypt.Net.BCrypt.GenerateSalt(13));

            return response;
        }*/

    }
}
