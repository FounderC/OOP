using System;
using КР.Commands.Base;
using КР.Models;
using КР.Service;

namespace КР.Commands
{
    public class TopUpBalanceCommand : ICommand
    {
        private UserService _userService;

        public TopUpBalanceCommand(UserService userService)
        {
            _userService = userService;
        }

        public void Execute(User user)
        {
            if (user == null)
            {
                Console.WriteLine("Ви не ввійшли в систему.");
                return;
            }

            Console.Write("Введіть суму для поповнення балансу: ");
            var amountStr = Console.ReadLine();
            decimal amount;
            if (!decimal.TryParse(amountStr, out amount))
            {
                Console.WriteLine("Введено некоректну суму. Спробуйте ще раз.");
                return;
            }

            _userService.TopUpBalance(user, amount);
            Console.WriteLine($"Баланс користувача {user.UserName} поповнено на {amount}.");
        }

        public string GetCommandInfo()
        {
            return "Поповнення балансу користувача";
        }
    }
}