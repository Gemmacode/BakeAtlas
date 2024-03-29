﻿using BakeAtlas.Application.DTO;
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
        void AddOrderItem(OrderItemDTO orderItemDto);
        void UpdateOrderItem(OrderItemDTO updatedOrderItemDto);
    }
}
