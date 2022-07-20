using CrossCuttingConcerns.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.DTOs
{
    public class UserSignUpOut
    {

        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public int DocumentType { get; set; }
        public int DocumentNumber { get; set; }
        public GenreEnum Genre { get; set; }
        public OperationResult Result { get; set; }
    }
}
