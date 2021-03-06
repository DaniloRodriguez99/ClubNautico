using CrossCuttingConcerns.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.DTOs
{
    public class GetUsersIn
    {
        public int PageSize { get; set; }
        public int From { get; set; }
        public Filter Filters { get; set; } = new Filter();

        public GetUsersIn(int pageSize, int from, Filter filters) {
            PageSize = pageSize;
            From = from;
            Filters = filters;
        }
    }
}
