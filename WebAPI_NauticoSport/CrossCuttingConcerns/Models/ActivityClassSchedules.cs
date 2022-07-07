using CrossCuttingConcerns.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Models
{
    public class ActivityClassSchedules
    {
        public int Id { get; set; }
        public ActivityClass ActivityClass { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
