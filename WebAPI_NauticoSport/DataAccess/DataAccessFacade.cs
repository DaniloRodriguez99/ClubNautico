using CrossCuttingConcerns.DTOs;
using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class DataAccessFacade
    {
        #region singleton
        private static DataAccessFacade _instance = new DataAccessFacade();

        private DataAccessFacade() { }

        public static DataAccessFacade Instance()
        {
            return _instance;
        }
        #endregion

        #region Configuration
        public void SetConfiguration(IConfiguration configuration)
        {
            ConfigurationClass.Instance().SetConfiguration(configuration);
        }
        #endregion 

        public LoginOut login(LoginIn input) {
            return AuthDataAccess.Instance().login(input);
        }

        public GetFeaturesByUserOut getFeaturesByUser(GetFeaturesByUserIn input)
        {
            return UserDataAccess.Instance().getFeatureByUser(input);
        }

        public UserSignUpOut userSignUp(UserSignUpIn input) {
            return UserDataAccess.Instance().userSignUp(input);
        }
    }
}
