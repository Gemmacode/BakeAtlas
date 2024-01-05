using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BakeAtlas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpPost("Add-Customer")]
        public IActionResult AddCustomer(CustomerDTO customer)
        {
            _customerService.AddCustomer(customer);
            return Ok("Customer Added Successfully");
        }

        [HttpGet("Get-Customer")]
        public IActionResult GetAllCustomer()
        {
            var customers = _customerService.GetAllCustomer();
            return Ok(customers);
        }

        [HttpGet("Get-Customer-By-Id")]
        public IActionResult GetCustomer(string id)
        {
            var customer = _customerService.GetCustomerById(id);
            return Ok(customer);
        }

        [HttpPut("Update-Customer")]
        public IActionResult UpdateCustomer(string customerId, CustomerDTO customer)
        {
            _customerService.UpdateCustomer(customerId, customer);
            return Ok("Customer updated successfully");
        }

        [HttpDelete("Delete-Customer")]
        public IActionResult DeleteCustomerId(string id)
        {
            _customerService.DeleteCustomer(id);  
            return Ok("Customer Deleted Successful");
        }
    }
}
