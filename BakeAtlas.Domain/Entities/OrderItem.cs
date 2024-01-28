using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public string OrderId { get; set; }
        public Order Order { get; set; }

        public string BakeryProductId { get; set; }
        public BakeryProduct BakeryProduct { get; set; }

        public int Quantity { get; set; }
    }
}
