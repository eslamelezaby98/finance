using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.dto.stock
{
    public class StockDtos
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = "";
        public string ComapnyName { get; set; } = "";
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = "";
        public long MarketCap { get; set; }
    }
}