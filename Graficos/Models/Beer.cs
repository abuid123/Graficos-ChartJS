using System;
using System.Collections.Generic;

namespace Graficos.Models
{
    public partial class Beer
    {
        public Beer()
        {
            Stocks = new HashSet<Stock>();
        }

        public int BeerId { get; set; }
        public string Name { get; set; } = null!;
        public int BrandId { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
