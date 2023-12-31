using System;
using КР.Commands.Base;
using КР.Models;

namespace КР.Commands
{
    public class CheckBalanceCommand : ICommand
    {
        public void Execute(User user)
        {
            if (user == null)
            {
                Console.WriteLine("Ви не ввійшли в систему.");
                return;
            }

            Console.WriteLine($"Ваш баланс: {user.Balance}");
        }

        public string GetCommandInfo()
        {
            return "Перевірка балансу користувача";
        }
    }
}