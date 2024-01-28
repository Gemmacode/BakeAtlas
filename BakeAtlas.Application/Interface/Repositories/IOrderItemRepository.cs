using BakeAtlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Application.Interface.Repositories
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        Task AddOrderItemAsync(OrderItem orderItem);
        void UpdateOrderItemAsync(OrderItem orderItem);
        void DeleteOrderItemAsync(OrderItem orderItem);
        OrderItem GetOrderItemById(string id);
        List<OrderItem> GetOrderItemsAsync();
    }
}
