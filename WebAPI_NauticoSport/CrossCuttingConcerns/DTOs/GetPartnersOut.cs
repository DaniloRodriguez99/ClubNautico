using CrossCuttingConcerns.Enums;
using CrossCuttingConcerns.Helpers;
using CrossCuttingConcerns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.DTOs
{
    public class GetPartnersOut
    {
        public List<User> Users { get; set; } = new List<User>();
        public OperationResult Result { get; set; }
    }
}
