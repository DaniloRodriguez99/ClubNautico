﻿using CrossCuttingConcerns.DTOs;
using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Domain
{
    public class DomainFacade
    {

        public DomainFacade(IConfiguration configuration)
        {
            DataAccess.DataAccessFacade.Instance().SetConfiguration(configuration);
        }

        public LoginOut login(LoginIn input) { 
            return AuthDomain.Instance().login(input);
        }
    }
}
