using AutoMapper;
using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;

namespace BakeAtlas.Application.ServicesImplementation
{
    public class CustomerService : ICustomerService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void AddCustomer(CustomerDTO customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            customer.Id = Guid.NewGuid().ToString();
            customer.UpdatedAt = DateTime.UtcNow;
            customer.CreatedAt = DateTime.UtcNow;

            _unitOfWork.CustomerRepository.AddCustomerAsync(customer);
            _unitOfWork.SaveChanges();
        }

        public void DeleteCustomer(string customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentNullException(nameof(customerId), "Customer Id is required");
            }

            var customer = _unitOfWork.CustomerRepository.GetCustomerById(customerId);

            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            _unitOfWork.CustomerRepository.DeleteCustomerAsync(customer);
            _unitOfWork.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            return _unitOfWork.CustomerRepository.GetCustomersAsync();
        }

        public Customer GetCustomerById(string customerId)
        {
            return _unitOfWork.CustomerRepository.GetCustomerById(customerId);
        }

        public void UpdateCustomer(string customerId, CustomerDTO customerDto)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentNullException(nameof(customerId), "Customer Id is required");
            }

            var existingCustomer = _unitOfWork.CustomerRepository.GetCustomerById(customerId);

            if (existingCustomer == null)
            {
                throw new Exception("Customer not found");
            }

            _mapper.Map(customerDto, existingCustomer);

            existingCustomer.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.CustomerRepository.UpdateCustomerAsync(existingCustomer);
            _unitOfWork.SaveChanges();
        }

    }
}
