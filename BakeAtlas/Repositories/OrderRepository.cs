using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Domain.Entities;
using BakeAtlas.Persistence.Context;
using System.Linq.Expressions;

namespace BakeAtlas.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly BakeAtlasDbContext _context;

        public OrderRepository(BakeAtlasDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddOrderAsync(Order order)
        {
            AddAsync(order);
        }

        public void DeleteAllOrderAsync(List<Order> order)
        {
            DeleteAllAsync(order);
        }

        public void DeleteOrderAsync(Order order)
        {
            DeleteAsync(order);
        }

        public List<Order> FindOrderAsync(Expression<Func<Order, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrder(Expression<Func<Order, bool>> customerid)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrderAsync()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
