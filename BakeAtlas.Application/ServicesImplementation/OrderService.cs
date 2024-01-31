using AutoMapper;
using BakeAtlas.Application.DTO;
using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BakeAtlas.Application.ServicesImplementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void AddOrder(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            order.Id = Guid.NewGuid().ToString();
            order.OrderDate = DateTime.UtcNow;
            order.UpdatedAt = DateTime.UtcNow;
            order.CreatedAt = DateTime.UtcNow;

            foreach (var itemDto in orderDto.OrderItems)
            {
                var orderItem = _mapper.Map<OrderItem>(itemDto);
                order.OrderItems.Add(orderItem);
            }

            _unitOfWork.OrderRepository.AddOrderAsync(order);
            _unitOfWork.SaveChanges();
        }

        public void DeleteOrder(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentNullException(nameof(orderId), "Order Id is required");
            }

            var order = _unitOfWork.OrderRepository.GetOrderById(orderId);

            if (order == null)
            {
                throw new Exception($"Order with Id {orderId} not found");
            }

            _unitOfWork.OrderRepository.DeleteOrderAsync(order);
            _unitOfWork.SaveChanges();
        }

        public List<Order> GetAllOrders()
        {
            return _unitOfWork.OrderRepository.GetOrderAsync();
        }

        public Order GetOrderById(string orderId)
        {
            return _unitOfWork.OrderRepository.GetOrderById(orderId);
        }

        public void UpdateOrder(string orderId, OrderDTO orderDto)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentNullException(nameof(orderId), "Order Id is required");
            }

            var existingOrder = _unitOfWork.OrderRepository.GetOrderById(orderId);

            if (existingOrder == null)
            {
                throw new Exception($"Order with Id {orderId} not found");
            }

            _mapper.Map(orderDto, existingOrder);

            existingOrder.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.OrderRepository.UpdateOrderAsync(existingOrder);
            _unitOfWork.SaveChanges();
        }
    }
}
