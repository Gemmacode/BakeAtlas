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
        [Required(ErrorMessage ="Product name is required.")]
        public string ProductName { get; set; }
        [MaxLength(500)]
        public string ProductDescription { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        public decimal ProductQuantity { get; set; }
        [Required]
        public decimal ProductDiscount { get; set; }
        [Required]
        public string ingredients { get; set;}

    }
}
