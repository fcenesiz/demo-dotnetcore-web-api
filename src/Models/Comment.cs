using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.src.Models;

namespace demo_dotnetcore_web_api.Models
{
    [Table("comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public int? StockId { get; set; }
        // Navigation prop
        public Stock? Stock { get; set; }

        //One-To-One Relationship prop example
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}