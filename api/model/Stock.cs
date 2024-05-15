using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.model
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = "";
        public string ComapnyName { get; set; } = "";
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = "";
        public long MarketCap { get; set; }
        public List<Comment> Comments { get; set; } = [];
    }
}