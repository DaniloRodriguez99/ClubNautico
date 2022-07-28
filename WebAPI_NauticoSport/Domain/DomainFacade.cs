using CrossCuttingConcerns.DTOs;
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

        public GetFeaturesByUserOut GetFeaturesByUser(GetFeaturesByUserIn input)
        {
            return new GetFeaturesByUserOut();//UserDomain.Instance().getFeaturesByUser(input);
        }

        public UserSignUpOut userSignUp(UserSignUpIn input) {
            return UserDomain.Instance().userSignUp(input);
        }

        public GetUsersOut getUsers(GetUsersIn input) {
            return UserDomain.Instance().getUsers(input);
        }

        public GetPartnersOut getPartners(GetPartnersIn input)
        {
            return PartnerDomain.Instance().getPartners(input);
        }

        public GetPartnerByIdOut getPartnerById(GetPartnerByIdIn input) {
            return PartnerDomain.Instance().getPartnerById(input);
        }
    }
}
