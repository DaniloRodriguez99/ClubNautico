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

        public LoginOut login(LoginIn input) 
        {
            return AuthDataAccess.Instance().login(input);
        }

        public UserSignUpOut userSignUp(UserSignUpIn input) 
        {
            return UserDataAccess.Instance().userSignUp(input);
        }

        public GetUsersOut getUsers(GetUsersIn input)
        {
            return UserDataAccess.Instance().getUsers(input);
        }

        public GetUserByIdOut getUserById(GetUserByIdIn input) 
        {
            return UserDataAccess.Instance().getUserById(input);
        }
    }
}
