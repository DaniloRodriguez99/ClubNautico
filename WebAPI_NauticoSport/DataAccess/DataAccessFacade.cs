using CrossCuttingConcerns.DTOs;
using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessFacade
    {
        public LoginOut login(LoginIn input) {
            return AuthDataAccess.Instance().login(input);
        }
    }
}
