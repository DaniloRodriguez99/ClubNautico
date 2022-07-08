using CrossCuttingConcerns.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    internal class AuthDomain
    {
        #region singleton
        private static AuthDomain _instance = new AuthDomain();

        private AuthDomain() { }

        public static AuthDomain Instance()
        {
            return _instance;
        }
        #endregion

        private DataAccess.DataAccessFacade dataAccessFacade = DataAccess.DataAccessFacade.Instance();

        public LoginOut login(LoginIn input)
        {
            return dataAccessFacade.login(input);
        }
    }
}
