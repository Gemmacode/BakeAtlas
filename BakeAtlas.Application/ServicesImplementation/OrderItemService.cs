using AutoMapper;
using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Application.DTO; 
using BakeAtlas.Domain.Entities;
using System;

namespace BakeAtlas.Application.ServicesImplementation
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddOrderItem(OrderItemDTO orderItemDto)
        {
            // Map OrderItemDTO to OrderItem
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);

            // Add logic to handle adding 'OrderItem' to the context
            _unitOfWork.OrderItemRepository.AddAsync(orderItem);
            _unitOfWork.SaveChanges();
        }

        public void UpdateOrderItem(OrderItemDTO updatedOrderItemDto)
        {
            // Map OrderItemDTO to OrderItem
            var updatedOrderItem = _mapper.Map<OrderItem>(updatedOrderItemDto);

            // Add logic to handle updating 'OrderItem' in the context
            var existingOrderItem = _unitOfWork.OrderItemRepository.GetByIdAsync(updatedOrderItem.Id);
            if (existingOrderItem != null)
            {
                // Update properties of existingOrderItem
                existingOrderItem.Quantity = updatedOrderItem.Quantity;

                // Mark the entity as modified
                _unitOfWork.OrderItemRepository.UpdateAsync(existingOrderItem);
                _unitOfWork.SaveChanges();
            }
        }
    }
}
