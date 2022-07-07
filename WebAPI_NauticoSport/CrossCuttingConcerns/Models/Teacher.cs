using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Models
{
    public class Teacher: User
    {
        public int TeacherId { get; set; }

        public int Cellphone { get; set; }

        public string Description { get; set; }

        public List<Activity> ActivitiesToTeach { get; set; }

        public List<ActivityClass> OwnActivityClasses { get; set; }
    }
}
