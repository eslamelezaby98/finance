using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.dto.stock
{
    public class CreateStockDto
    {
        [Required]
        public string Symbol { get; set; } = "";
        [Required]
        public string ComapnyName { get; set; } = "";
        [Required]
        [Range(1,10000000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001,100)]
        public decimal LastDiv { get; set; }
        [Required]
        public string Industry { get; set; } = "";
        [Required]
        public long MarketCap { get; set; }
    }
}