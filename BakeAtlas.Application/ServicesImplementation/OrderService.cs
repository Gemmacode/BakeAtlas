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
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public void AddOrder(OrderDTO orderDto)
        //{
        //    // Generate a unique order ID
        //    string orderId = Guid.NewGuid().ToString();

        //    // Map DTO to entity
        //    Order order = _mapper.Map<Order>(orderDto);
        //    order.Id = orderId;
        //    order.OrderDate = DateTime.UtcNow;

        //    // Add order to the database
        //    _unitOfWork.OrderRepository.AddOrderAsync(order);
        //    _unitOfWork.SaveChanges();

        //    // Add order items to the order
        //    foreach (var orderItemDto in orderDto.OrderItems)
        //    {
        //        AddOrderItemToOrder(orderId, orderItemDto);
        //    }
        //}

        //public void AddOrderItemToOrder(string orderId, OrderItemDTO orderItemDto)
        //{
        //    // Retrieve the order or throw an exception if not found
        //    Order order = GetOrderById(orderId);

        //    // Map DTO to entity
        //    OrderItem orderItem = _mapper.Map<OrderItem>(orderItemDto);
        //    orderItem.OrderId = orderId; // Assign the order ID

        //    // Add the order item to the order
        //    order.OrderItems ??= new List<OrderItem>();
        //    order.OrderItems.Add(orderItem);

        //    // Save changes
        //    _unitOfWork.SaveChanges();
        //}
        public void DeleteOrder(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentNullException(nameof(orderId), "Order Id is required");
            }

            var order = GetOrderById(orderId);

            _unitOfWork.OrderRepository.DeleteOrderAsync(order);
            _unitOfWork.SaveChanges();
        }
        public void AddOrder(OrderDTO orderDto)
        {
            // Generate a unique order ID
            string orderId = Guid.NewGuid().ToString();

            // Map DTO to entity
            Order order = _mapper.Map<Order>(orderDto);
            order.Id = orderId;
            order.OrderDate = DateTime.UtcNow;

            // Map order items DTO to entities and add them to the order
            order.OrderItems = orderDto.OrderItems.Select(itemDto =>
            {
                var orderItem = _mapper.Map<OrderItem>(itemDto);
                orderItem.OrderId = orderId;
                return orderItem;
            }).ToList();

            // Add order to the database
            _unitOfWork.OrderRepository.AddOrderAsync(order);
            _unitOfWork.SaveChanges();
        }
        public List<Order> GetAllOrders()
        {
            return _unitOfWork.OrderRepository.GetOrderAsync();
        }

        public Order GetOrderById(string orderId)
        {
            Order order = _unitOfWork.OrderRepository.GetOrderById(orderId);

            if (order == null)
            {
                throw new Exception($"Order with Id {orderId} not found");
            }

            return order;
        }

        public void UpdateOrder(string orderId, OrderDTO orderDto)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentNullException(nameof(orderId), "Order Id is required");
            }

            var existingOrder = GetOrderById(orderId);

            _mapper.Map(orderDto, existingOrder);

            existingOrder.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.OrderRepository.UpdateOrderAsync(existingOrder);
            _unitOfWork.SaveChanges();
        }

        //private Order GetOrderById(string orderId)
        //{
        //    Order order = _unitOfWork.OrderRepository.GetOrderById(orderId);

        //    if (order == null)
        //    {
        //        throw new Exception($"Order with ID {orderId} not found");
        //    }

        //    return order;
        //}
    }
}
