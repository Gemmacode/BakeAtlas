using BakeAtlas.Application.DTO;
using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BakeAtlas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }
        [HttpPost("Add-Order")]
        public IActionResult AddOrder(OrderDTO orderDto)
        {
            _orderService.AddOrder(orderDto);   
            return Ok("Order added successfully");
        }

        //[HttpPost("Add-OrderItem")]
        //public IActionResult AddOrderItemToOrder(string orderId, OrderItemDTO orderItemDto)
        //{
        //    _orderService.AddOrderItemToOrder(orderId, orderItemDto);
        //    return Ok("OrderItem added successfully");
        //}

        [HttpGet("Get-All-Orders")]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("Get-Order-By-Id")]
        public IActionResult GetOrderById(string id)
        {
            var order = _orderService.GetOrderById(id);

            if (order == null)
            {
                return NotFound($"Order with Id {id} not found");
            }

            return Ok(order);
        }

        [HttpPut("Update-Order")]
        public IActionResult UpdateOrder(string orderId, [FromBody] OrderDTO orderDto)
        {
            _orderService.UpdateOrder(orderId, orderDto);
            return Ok("Order updated successfully");
        }

        [HttpDelete("Delete-Order")]
        public IActionResult DeleteOrder(string id)
        {
            _orderService.DeleteOrder(id);
            return Ok("Order deleted successfully");
        }
    }
}
