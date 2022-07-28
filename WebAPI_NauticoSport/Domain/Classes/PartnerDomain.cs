using CrossCuttingConcerns.DTOs;
using CrossCuttingConcerns.Enums;
using CrossCuttingConcerns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    internal class PartnerDomain
    {
        #region singleton
        private static PartnerDomain _instance = new PartnerDomain();

        private PartnerDomain() { }

        public static PartnerDomain Instance() {
            return _instance;
        }
        #endregion

        #region DataAccess

        private DataAccess.DataAccessFacade dataAccessFacade = DataAccess.DataAccessFacade.Instance();

        #endregion

        public GetPartnerByIdOut getPartnerById(GetPartnerByIdIn input)
        {
            GetPartnerByIdOut result = new GetPartnerByIdOut() { Result = OperationResult.failure };

            GetUserByIdOut User = dataAccessFacade.getUserById(new GetUserByIdIn() { UserId = input.PartnerId });

            if (User.Result == OperationResult.success && User.Role == RoleEnum.partner)
            {
                result = new GetPartnerByIdOut
                {
                    UserId = User.UserId,
                    Birthday = User.Birthday,
                    CreationDate = User.CreationDate,
                    Email = User.Email,
                    Ci = User.Ci,
                    Genre = User.Genre,
                    Lastname = User.Lastname,
                    Name = User.Name,
                    ProfileIMG = User.ProfileIMG,
                    Result = User.Result,
                    Role = User.Role
                };
            }

            return result;
        }


        public GetPartnersOut getPartners(GetPartnersIn input)
        {
            GetPartnersOut result = new GetPartnersOut() { Result = OperationResult.failure };

            GetUsersOut output = dataAccessFacade.getUsers(new GetUsersIn(input.PageSize, input.From, input.Filters));

            if (output.Users != null)
            {
                foreach (User user in output.Users)
                {
                    if (user.Role == RoleEnum.partner)
                    {
                        result.Users.Add(user);
                    }
                }

            }

            result.Result = output.Result;

            return result;
        }
    }
}
