using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public string OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public string BakeryProductId { get; set; }
        public BakeryProduct BakeryProduct { get; set; }

        public int Quantity { get; set; }
    }
}
