using BakeAtlas.Application.Interface.Repositories;
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
            ProductRepository = new BakeryProductRepository(_dbContext);
        }

        public ICustomerRepository CustomerRepository { get; private set; }

        public IOrderRepository OrderRepository { get; private set; }

        public IBakeryProductRepository ProductRepository { get; private set; }

        

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public int SaveChangesAync()
        {
            return _dbContext.SaveChanges();

        }
    }
}
