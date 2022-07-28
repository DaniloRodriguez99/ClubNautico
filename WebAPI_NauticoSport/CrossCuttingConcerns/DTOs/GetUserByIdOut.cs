using CrossCuttingConcerns.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.DTOs
{
    public class GetUserByIdOut
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Ci { get; set; }
        public string Email { get; set; }
        public GenreEnum Genre { get; set; }
        public string ProfileIMG { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreationDate { get; set; }
        public RoleEnum Role { get; set; }
        public OperationResult Result { get; set; }
    }
}
