using CrossCuttingConcerns.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.DTOs
{
    public class PartnerSignUpIn
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public int DocumentType { get; set; }
        public string Password { get; set; }
        public int DocumentNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public GenreEnum Genre { get; set; }
    }
}
