using CrossCuttingConcerns.Enums;
using CrossCuttingConcerns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.DTOs
{
    public class GetFeaturesByUserOut
    {
        public List<Feature>? Features { get; set; }
        public OperationResult operationResult { get; set; }
    }
}
