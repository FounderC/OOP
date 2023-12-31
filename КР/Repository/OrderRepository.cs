using System.Collections.Generic;
using System.Linq;
using КР.Models;
using КР.Repository.Base;

namespace КР.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public List<Order> GetOrdersByUser(User user)
        {
            return _orders.Where(o => o.User == user).ToList();
        }
    }
}