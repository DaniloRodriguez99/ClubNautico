using CrossCuttingConcerns.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Models
{
    public class Partner: User
    {
        public string PartnerId { get; set; }

        public PartnerTypeEnum PartnerType { get; set; }

    }
}
