using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class QueryObject
    {
        public string? Search { get; set; }
        public string? SortBy { get; set; }
        public bool IsSortAscending { get; set; }

    }
}