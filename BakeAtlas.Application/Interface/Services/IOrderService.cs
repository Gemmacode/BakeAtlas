using BakeAtlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Application.Interface.Services
{
    public interface IOrderService
    {
        void AddOrder(Order customer);
        void DeleteOrder(string orderId);
        List<Order> GetAllOrder();
        Order GetOrderById(string orderId);
        void UpdateOrder(Order order);
    }
}
