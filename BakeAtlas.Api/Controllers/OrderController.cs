using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BakeAtlas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Add-Order")]
        public IActionResult AddOrder(OrderDTO order)
        {
            _orderService.AddOrder(order);
            return Ok("Order Added Successfully");
        }

        [HttpGet("Get-Order")]
        public IActionResult GetAllOrder()
        {
            var order = _orderService.GetAllOrder();
            return Ok(order);
        }

        [HttpGet("Get-Order-By-Id")]
        public IActionResult GetOrder(string id)
        {
            var order = _orderService.GetOrderById(id);
            return Ok(order);
        }

        [HttpPut("Update-Order")]
        public IActionResult UpdateCustomer(string orderId, OrderDTO order)
        {
            _orderService.UpdateOrder(orderId, order);
            return Ok("Order updated successfully");
        }

        [HttpDelete("Delete-Order")]
        public IActionResult DeleteOrderId(string id)
        {
            _orderService.DeleteOrder(id);
            return Ok("Order Deleted Successful");
        }
    }
}

