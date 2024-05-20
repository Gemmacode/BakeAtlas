using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Domain.Entities
{
    public class BakeryProductDTO 
    {
        public string ProductName { get; set; }      
        public decimal ProductPrice { get; set; }
        public decimal ProductQuantity { get; set; }  
        public ICollection<Order> Order { get; set; }



    }
}
