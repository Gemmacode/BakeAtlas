using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Domain.Entities;
using BakeAtlas.Persistence.Context;


namespace BakeAtlas.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BakeAtlasDbContext _dbContext;

        public UnitOfWork(BakeAtlasDbContext dbContext)
        {
            _dbContext = dbContext;
            CustomerRepository = new CustomerRepository (_dbContext);
            OrderRepository = new OrderRepository(_dbContext);
            BakeryProductRepository = new BakeryProductRepository(_dbContext);
            OrderItemRepository = new OrderItemRepository(_dbContext);
        }

        public ICustomerRepository CustomerRepository { get; private set; }

        public IOrderRepository OrderRepository { get; private set; }

        public IBakeryProductRepository BakeryProductRepository { get; private set; }
        public IOrderItemRepository OrderItemRepository { get; private set; }




        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

    }
}
