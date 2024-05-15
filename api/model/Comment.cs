using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.model
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int? StockId { get; set; }
        public Stock? Stock { get; set; }
    }
}