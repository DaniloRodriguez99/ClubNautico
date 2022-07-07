using CrossCuttingConcerns.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Helpers
{
    public class Schedule
    {
        public DaysEnum Day { get; set; }
        public string HourStart { get; set; }
        public string HourEnd { get; set; }
    }
}
