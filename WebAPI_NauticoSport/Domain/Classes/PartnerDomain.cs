using CrossCuttingConcerns.DTOs;
using CrossCuttingConcerns.Enums;
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

        /*public PartnerSignUpOut partnerSignUp(PartnerSignUpIn input) {
            //TODO verificar que el usuario tenga la feature
            PartnerSignUpOut response = new PartnerSignUpOut()
            {
                operationResult = OperationResult.failure
            };

            if (input.Password == input.RepeatedPassword) 
            {
                response = dataAccessFacade.partnerSignUp(input);
            }

            return response;
        }*/
    }
}
