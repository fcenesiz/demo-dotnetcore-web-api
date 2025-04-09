using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_dotnetcore_web_api.src.Helpers
{
    public class CommentQueryObject
    {
        public string Symbol { get; set; }
        public bool IsDecsending { get; set; } = true;
    }
}