using BakeAtlas.Application.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Domain.Entities
{
    public class OrderDTO 
    {
        public string CustomerId { get; set; }
        public string Description { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }


    }
}
