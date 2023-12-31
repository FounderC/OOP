using System;
using КР.Commands.Base;
using КР.Models;
using КР.Service;

namespace КР.Commands
{
    public class DisplayOrderHistoryCommand : ICommand
    {
        private OrderService _orderService;

        public DisplayOrderHistoryCommand(OrderService orderService)
        {
            _orderService = orderService;
        }

        public void Execute(User user)
        {
            if (user == null)
            {
                Console.WriteLine("Ви не ввійшли в систему.");
                return;
            }

            var orders = _orderService.GetOrdersByUser(user);
            if (orders.Count == 0)
            {
                Console.WriteLine("Історія замовлень користувача порожня.");
                return;
            }

            foreach (var order in orders)
            {
                Console.WriteLine(
                    $"Назва товару: {order.Product.Name}, Ціна: {order.Product.Price}, Дата замовлення: {order.OrderDate}");
            }
        }


        public string GetCommandInfo()
        {
            return "Перегляд історії замовлень користувача";
        }
    }
}