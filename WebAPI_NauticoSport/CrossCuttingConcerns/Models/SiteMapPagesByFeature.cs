using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Models
{
    public class SiteMapPagesByFeature
    {
        public int Feature { get; set; }
        public List<SiteMapPages>? SitePages { get; set; }

    }
}
