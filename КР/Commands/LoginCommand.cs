using System;
using КР.Commands.Base;
using КР.Models;
using КР.Service;

namespace КР.Commands
{
    public class LoginCommand : ICommand
    {
        private UserService _userService;

        public User LoggedInUser { get; private set; }

        public LoginCommand(UserService userService)
        {
            _userService = userService;
        }

        public void Execute(User user)
        {
            if (user != null)
            {
                Console.WriteLine(
                    "Ви вже увійшли в систему. Будь ласка, вийдіть з системи, щоб увійти під іншим обліковим записом.");
                return;
            }

            Console.Write("Введіть ім'я користувача: ");
            var userName = Console.ReadLine();
            Console.Write("Введіть пароль: ");
            var password = Console.ReadLine();
            LoggedInUser = _userService.Login(userName, password);

            if (LoggedInUser == null)
            {
                Console.WriteLine("Невдалий вхід. Будь ласка, перевірте своє ім'я користувача та пароль.");
            }
            else
            {
                Console.WriteLine($"Успішний вхід, {LoggedInUser.UserName}!");
            }
        }


        public string GetCommandInfo()
        {
            return "Вхід користувача";
        }
    }
}