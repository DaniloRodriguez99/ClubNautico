using CrossCuttingConcerns.DTOs;
using CrossCuttingConcerns.Enums;
using System;
using System.Collections.Generic;
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
            return new LoginOut() { operationResult = OperationResult.success };
        }
    }
}
