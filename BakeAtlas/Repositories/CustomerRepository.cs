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
            DeleteAllAsync(customers);   
        }

        public void DeleteCustomerAsync(Customer customer)
        {
           DeleteAsync(customer);
        }

        public Customer GetCustomerById(string id)
        {
            return GetByIdAsync(id);
        }

        public List<Customer> GetCustomersAsync()
        {
            return GetAllAsync();
        }

        public void UpdateCustomerAsync(Customer student)
        {
             UpdateAsync(student);
        }
    }
}
