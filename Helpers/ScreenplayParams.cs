using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class ScreenplayParams : PaginationParams
    {
        public string Search { get; set; } = "";
        public string Category { get; set; } = "movie";
        public string OrderBy { get; set; } = "Title";
    }
}
