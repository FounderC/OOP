using System;
using КР.Commands.Base;
using КР.Models;
using КР.Service;

namespace КР.Commands
{
    public class DisplayProductsCommand : ICommand
    {
        private ProductService _productService;

        public DisplayProductsCommand(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute(User user)
        {
            if (user == null)
            {
                Console.WriteLine("Ви не ввійшли в систему.");
                return;
            }

            var products = _productService.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"Назва товару: {product.Name}, Ціна: {product.Price}");
            }
        }

        public string GetCommandInfo()
        {
            return "Відображення всіх товарів";
        }
    }
}