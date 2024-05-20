using BakeAtlas.Domain.Enum;
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
        public string ProductId { get; set; }
        public decimal TotalCost { get; set; }
        public OrderStatus Status { get; set; }
       
      

    }
}
