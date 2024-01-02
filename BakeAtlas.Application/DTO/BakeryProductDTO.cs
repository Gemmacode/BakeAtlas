using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Domain.Entities
{
    public class BakeryProductDTO :BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal ProductDiscount { get; set; }
        public string ingredients { get; set;}

    }
}
