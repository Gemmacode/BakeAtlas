using BakeAtlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Application.Interface.Services
{
    public interface IOrderItemService
    {
        void AddOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem updatedOrderItem);
    }
}
