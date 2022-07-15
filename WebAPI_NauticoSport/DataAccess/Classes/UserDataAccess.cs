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

        public GetFeaturesByUserOut getFeatureByUser (GetFeaturesByUserIn input)
        {
            //to get the connection string 
            var connectionstring = ConfigurationClass.Instance().GetConnectionString("nauticoSportConnectionString");
            //build the sqlconnection and execute the sql command
            GetFeaturesByUserOut response = new GetFeaturesByUserOut()
            {
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
                            var features = new List<Feature>();
                            
                              

                            response.operationResult = OperationResult.success;
                            response.Features = features;
                        }
                    }
                }
            }
            return response;
        }
    }
}
