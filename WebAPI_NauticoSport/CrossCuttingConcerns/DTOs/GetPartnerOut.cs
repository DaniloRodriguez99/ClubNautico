using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.DTOs
{
    public class GetPartnerOut
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

    }
}
