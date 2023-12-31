using BakeAtlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Application.Interface.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        List<Order> GetOrderAsync();
        List<Order> GetAllOrder(Expression<Func<Order, bool>> customerid);
        void AddOrderAsync(Order order);
        void DeleteOrderAsync(Order order);
        void DeleteAllOrderAsync(List<Order> order);
        public List<Order> FindOrderAsync(Expression<Func<Order, bool>> condition);
        Order GetOrderById(string id);
        void UpdateOrderAsync(Order order);
    }
}
