using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Domain.Entities
{
    public class Order
    {
        public string CustomerFullName { get; set; }
        public string Description { get; set; }
        public List<BakeryProduct> products { get; set; }
    

    }
}
