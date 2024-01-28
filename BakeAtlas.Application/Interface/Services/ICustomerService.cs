using BakeAtlas.Domain.Entities;

namespace BakeAtlas.Application.Interface.Services
{
    public interface ICustomerService
    {
        void AddCustomer(CustomerDTO customerDto);
        void DeleteCustomer(string customerId);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(string customerId);
        void UpdateCustomer(string customerid, CustomerDTO customerDto);
    }
}
