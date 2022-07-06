using CrossCuttingConcerns.DTOs;
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


    }
}
