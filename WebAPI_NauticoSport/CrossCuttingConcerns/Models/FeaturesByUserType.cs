using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Models
{
    public class FeaturesByUserType
    {
        public int UserType { get; set; }
        public List<Feature> Features { get; set; }
    }
}
