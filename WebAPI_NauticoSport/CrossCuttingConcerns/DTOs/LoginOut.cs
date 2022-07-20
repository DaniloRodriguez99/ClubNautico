using CrossCuttingConcerns.Enums;
using CrossCuttingConcerns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.DTOs
{
    public class LoginOut
    {
        public OperationResult Result { get; set; }

        public string Token { get; set; }

        public User User { get; set; }
    }
}
