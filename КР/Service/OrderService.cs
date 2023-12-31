using System;
using КР.Repository.Base;
using System.Collections.Generic;
using КР.Models;

namespace КР.Service
{
    public class OrderService
    {
        private IOrderRepository _orderRepository;
        private UserService _userService;
        private ProductService _productService;

        public OrderService(IOrderRepository orderRepository, UserService userService, ProductService productService)
        {
            _orderRepository = orderRepository;
            _userService = userService;
            _productService = productService;
        }

        public List<Order> GetOrdersByUser(User user)
        {
            return _orderRepository.GetOrdersByUser(user);
        }

        public void MakeOrder(User user, string productName)
        {
            var product = _productService.GetProduct(productName);
            if (product == null)
            {
                Console.WriteLine("Товар з такою назвою не знайдено.");
                return;
            }

            if (user.Balance >= product.Price)
            {
                user.Balance -= product.Price;
                _userService.UpdateUser(user);

                var order = new Order { User = user, Product = product, OrderDate = DateTime.Now };
                _orderRepository.AddOrder(order);

                Console.WriteLine($"Користувач {user.UserName} купив товар {productName}.");
            }
            else
            {
                Console.WriteLine("На вашому балансі недостатньо коштів для покупки цього товару.");
            }
        }
    }
}