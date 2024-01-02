using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Application.Interface.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IBakeryProductRepository BakeryProductRepository { get; }
        int SaveChanges();
    }
}
