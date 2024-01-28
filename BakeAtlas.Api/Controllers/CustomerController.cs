using AutoMapper;
using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BakeAtlas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("Add-Customer")]
        public IActionResult AddCustomer([FromBody] CustomerDTO customerDto)
        {
            _customerService.AddCustomer(customerDto);
            return Ok("Customer added successfully");
        }

        [HttpGet("Get-All-Customers")]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("Get-Customer-By-Id")]
        public IActionResult GetCustomerById(string id)
        {
            var customer = _customerService.GetCustomerById(id);
            return Ok(customer);
        }

        [HttpPut("Update-Customer")]
        public IActionResult UpdateCustomer(string customerId, [FromBody] CustomerDTO customerDto)
        {
            _customerService.UpdateCustomer(customerId, customerDto);
            return Ok("Customer updated successfully");
        }

        [HttpDelete("Delete-Customer")]
        public IActionResult DeleteCustomer(string id)
        {
            _customerService.DeleteCustomer(id);
            return Ok("Customer deleted successfully");
        }
    }
}
