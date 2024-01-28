using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string Description { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        // Navigation property for OrderItems
        public List<OrderItem> OrderItems { get; set; }


    }
}
