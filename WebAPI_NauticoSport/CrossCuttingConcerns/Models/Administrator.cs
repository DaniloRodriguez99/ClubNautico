using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Models
{
    public class Administrator: User
    {
        public int AdminId { get; set; }
    }
}
