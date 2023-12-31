using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Domain.Entities;
using BakeAtlas.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly BakeAtlasDbContext _context;

        public CustomerRepository(BakeAtlasDbContext context) : base(context) 
        {
            _context = context;
        }

        public void AddCustomerAsync(Customer customer)
        {
            AddAsync(customer);
        }

        public void DeleteAllCustomersAsync(List<Customer> customers)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Customer> FindCustomerAsync(Expression<Func<Customer, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomerAsync(Customer student)
        {
            throw new NotImplementedException();
        }
    }
}
