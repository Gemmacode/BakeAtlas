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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrder(OrderDTO customer)
        {
            var ord = new Order
            {
                Id = Guid.NewGuid().ToString(),
                CustomerFullName = customer.CustomerFullName,
                Description = customer.Description,
                Products = customer.products,
                OrderDate = DateTime.Now,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            };
            _unitOfWork.OrderRepository.AddOrderAsync(ord);
            _unitOfWork.SaveChanges();
            
        }

        public void DeleteOrder(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentNullException("order Id is required");
            };
            var order = _unitOfWork.OrderRepository.GetOrderById(orderId);
            if (order == null)
            {
                throw new Exception("Product not found");
            }
            _unitOfWork.OrderRepository.DeleteOrderAsync(order);
            _unitOfWork.SaveChanges();
        }

        public List<Order> GetAllOrder()
        {
            return _unitOfWork.OrderRepository.GetOrderAsync();
        }

        public Order GetOrderById(string orderId)
        {
            return _unitOfWork.OrderRepository.GetOrderById(orderId);
        }

        public void UpdateOrder(string orderid, OrderDTO order)
        {
            if (string.IsNullOrWhiteSpace(orderid))
            {
                throw new ArgumentNullException("Order Id is required");
            }

            var existingorder = _unitOfWork.OrderRepository.GetOrderById(orderid);

            if (existingorder == null)
            {
                throw new Exception("Order not found");
            }

            //update the properties of the existing product
            existingorder.CustomerFullName = order.CustomerFullName; 
            existingorder.Description = order.Description;
            existingorder.Products = order.products;
            existingorder.UpdatedAt = DateTime.UtcNow;
      
            _unitOfWork.OrderRepository.UpdateOrderAsync(GetOrderById(orderid));
            _unitOfWork.SaveChanges();
        }
    }
}
