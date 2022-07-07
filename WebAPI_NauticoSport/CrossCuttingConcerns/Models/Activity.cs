using CrossCuttingConcerns.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ActivityCategoryEnum Category { get; set; }
        public string Description { get; set; }
    }
}
