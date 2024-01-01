using BakeAtlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Application.Interface.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        List<Customer> GetCustomersAsync();
        void AddCustomerAsync(Customer customer);
        void DeleteCustomerAsync(Customer customer);
        void DeleteAllCustomersAsync(List<Customer> customers);
        Customer GetCustomerById(string id);
        void UpdateCustomerAsync(Customer student);
    }
}
