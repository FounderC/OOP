using System;
using КР.Commands.Base;
using КР.Models;
using КР.Service;

namespace КР.Commands
{
    public class BuyProductCommand : ICommand
    {
        private OrderService _orderService;
        private ProductService _productService;

        public BuyProductCommand(OrderService orderService, ProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        public void Execute(User user)
        {
            if (user == null)
            {
                Console.WriteLine("Ви не ввійшли в систему.");
                return;
            }

            Console.Write("Введіть назву товару: ");
            var productName = Console.ReadLine();
            var product = _productService.GetProduct(productName);
            if (product == null)
            {
                Console.WriteLine("Товар з такою назвою не знайдено.");
                return;
            }

            _orderService.MakeOrder(user, productName);
        }


        public string GetCommandInfo()
        {
            return "Купівля товару користувачем";
        }
    }
}