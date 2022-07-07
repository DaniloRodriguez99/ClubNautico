using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Models
{
    public class ActivityClass
    {
        public int Id { get; set; }
        public Teacher Teacher { get; set; }
        public Activity Activity { get; set; }
        public List<Partner> Students { get; set; }
    }
}
