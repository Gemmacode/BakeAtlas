using BakeAtlas.Domain.Enum;

namespace BakeAtlas.Domain.Entities
{
    public class OrderDTO 
    {
        public string CustomerId { get; set; }
        public string ProductId { get; set; }
        public decimal TotalCost { get; set; }
        public OrderStatus Status { get; set; }




    }
}
