using CrossCuttingConcerns.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Models
{
    public class Notice
    {
        public int Id { get; set; }
        public Administrator Creator { get; set; }
        public string Title { get; set; }
        public string BodyMessage { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public ImportantLevelEnum ImportantLevel { get; set; }
    }
}
