using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Models
{
    public class SiteMapPages
    {
        public int Id { get; set; }
        public string PageKey { get; set; }
        public SiteMapPages Parent { get; set; }
        public int Ordinal { get; set; }
    }
}
