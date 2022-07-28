using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Helpers
{
    public class Filter
    {
        public int Ci { get; set; }
        public Boolean Male { get; set; }
        public Boolean Female { get; set; }
        public Boolean Other { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Role { get; set; }

    }
}
