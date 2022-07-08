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
        public OperationResult operationResult { get; set; }

        public string token { get; set; }

        public User user { get; set; }
    }
}
