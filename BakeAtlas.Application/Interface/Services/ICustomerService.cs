using BakeAtlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Application.Interface.Services
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void DeleteCustomer(string customerId);
        List<Customer> GetAllCustomer();
        Customer GetCustomerById(string customerId);
        void UpdateCustomer(Customer customer);
    }
}
