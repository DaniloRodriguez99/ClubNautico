using CrossCuttingConcerns.Enums;
using CrossCuttingConcerns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.DTOs
{
    public class GetUsersOut
    {
        public List<User> Users { get; set; }
        public OperationResult Result { get; set; }
    }
}
