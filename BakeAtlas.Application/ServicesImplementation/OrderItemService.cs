using AutoMapper;
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
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            // Add logic to handle adding 'OrderItem' to the context
            _unitOfWork.OrderItemRepository.AddAsync(orderItem);
            _unitOfWork.SaveChanges();
        }

        public void UpdateOrderItem(OrderItem updatedOrderItem)
        {
            // Add logic to handle updating 'OrderItem' in the context
            var existingOrderItem = _unitOfWork.OrderItemRepository.GetByIdAsync(updatedOrderItem.Id);
            if (existingOrderItem != null)
            {
                // Update properties of existingOrderItem
                existingOrderItem.Quantity = updatedOrderItem.Quantity;

                // Save changes to the database
                _unitOfWork.SaveChanges();
            }
        }
    }
}
