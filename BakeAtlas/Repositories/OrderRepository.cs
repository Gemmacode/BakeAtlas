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
        public void DeleteOrderAsync(Order order)
        {
            DeleteAsync(order);
        }

        public List<Order> GetOrderAsync()
        {
            return GetAllAsync();
        }

        public Order GetOrderById(string id)
        {
            return GetByIdAsync(id);
        }

        public void UpdateOrderAsync(Order order)
        {
            _context.Update(order);
        }
    }
}
