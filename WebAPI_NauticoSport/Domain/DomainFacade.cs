using CrossCuttingConcerns.DTOs;
using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DomainFacade
    {
        public LoginOut login(LoginIn input) { 
            return AuthDomain.Instance().login(input);
        }
    }
}
