using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Models
{
    public class Event: Notice
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Hour { get; set; }

    }
}
