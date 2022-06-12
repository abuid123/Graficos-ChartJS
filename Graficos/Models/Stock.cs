using System;
using System.Collections.Generic;

namespace Graficos.Models
{
    public partial class Stock
    {
        public int StockId { get; set; }
        public int BeerId { get; set; }
        public int Quantity { get; set; }

        public virtual Beer Beer { get; set; } = null!;
    }
}
