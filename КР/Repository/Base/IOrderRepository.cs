using System.Collections.Generic;
using КР.Models;

namespace КР.Repository.Base
{
    public interface IOrderRepository 
    {
        void AddOrder(Order order);
        List<Order> GetOrdersByUser(User user);
    }
}