using CrossCuttingConcerns.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.DTOs
{
    public class GetPartnerOut
    {

        public string PartnerId { get; set; }

        public PartnerTypeEnum PartnerType { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public int CI { get; set; }

        public string Email { get; set; }

        public GenreEnum Genre { get; set; }

        //public string ProfileIMG { get; set; } TODO: investigar sobre como guardar las imagenes etc

        public DateTime Birthday { get; set; }

        public DateTime CreationDate { get; set; }

        public RoleEnum Role { get; set; }

        public OperationResult OperationResult { get; set; }

    }
}
