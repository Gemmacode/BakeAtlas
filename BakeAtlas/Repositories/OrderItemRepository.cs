using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Domain.Entities;
using BakeAtlas.Persistence.Context;

namespace BakeAtlas.Persistence.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        private readonly BakeAtlasDbContext _context;

        public OrderItemRepository(BakeAtlasDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddOrderItemAsync(OrderItem orderItem)
        {
            await AddAsync(orderItem);
        }

        public void DeleteOrderItemAsync(OrderItem orderItem)
        {
            DeleteAsync(orderItem);
        }

        public OrderItem GetOrderItemById(string id)
        {
            return GetByIdAsync(id);
        }

        public List<OrderItem> GetOrderItemsAsync()
        {
            return GetAllAsync();
        }

        public void UpdateOrderItemAsync(OrderItem orderItem)
        {
            UpdateAsync(orderItem);
        }
    }

}
