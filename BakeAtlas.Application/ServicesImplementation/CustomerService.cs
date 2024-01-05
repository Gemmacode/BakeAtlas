using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Application.ServicesImplementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCustomer(CustomerDTO customer)
        {
            var cus = new Customer
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            };
            _unitOfWork.CustomerRepository.AddCustomerAsync(cus);
            _unitOfWork.SaveChanges();
        }

        public void DeleteCustomer(string customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentNullException("Customer Id is required");
            }
            var customer = _unitOfWork.CustomerRepository.GetCustomerById(customerId);  
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            _unitOfWork.CustomerRepository.DeleteCustomerAsync(customer);
            _unitOfWork.SaveChanges();
        }

        public List<Customer> GetAllCustomer()
        {
            return _unitOfWork.CustomerRepository.GetCustomersAsync();
        }

        public Customer GetCustomerById(string customerId)
        {
            return _unitOfWork.CustomerRepository.GetCustomerById(customerId);
        }

        public void UpdateCustomer(string customerid, CustomerDTO customer)
        {
            if (string.IsNullOrWhiteSpace(customerid))
            {
                throw new ArgumentNullException("Customer Id is required");
            }
            var existingCustomer = _unitOfWork.CustomerRepository.GetCustomerById(customerid);
            if (customer == null)
            {
                throw new Exception("Customer not Found");
            }
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.Address = customer.Address;
            existingCustomer.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.CustomerRepository.UpdateCustomerAsync(existingCustomer);
            _unitOfWork.SaveChanges();
        }
    }
}
