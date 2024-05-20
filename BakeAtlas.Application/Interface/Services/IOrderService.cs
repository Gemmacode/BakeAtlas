using BakeAtlas.Domain.Entities;

namespace BakeAtlas.Application.Interface.Services
{
    public interface IOrderService
    {
        void AddOrder(OrderDTO orderDto);
        //void AddOrderItemToOrder(string orderId, OrderItemDTO orderItemDto);
        void DeleteOrder(string orderId);
        List<Order> GetAllOrders();
        Order GetOrderById(string orderId);
        void UpdateOrder(string orderid, OrderDTO orderDto);
    }
}
