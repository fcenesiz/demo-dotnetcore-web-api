using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_dotnetcore_web_api.src.Helpers
{
    public class StockQueryObject
    {

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;


    }
}