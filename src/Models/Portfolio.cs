using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.Models;

namespace demo_dotnetcore_web_api.src.Models
{
    [Table("portfolios")]
    public class Portfolio
    {
        public string AppUserId { get; set; }
        public int StockId { get; set; }

        // Navigation props
        public AppUser AppUser { get; set; }
        public Stock Stock { get; set; }


    }
}