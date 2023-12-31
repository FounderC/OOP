using System;
using КР.Commands.Base;
using КР.Models;
using КР.Service;

namespace КР.Commands
{
    public class RegisterUserCommand : ICommand
    {
        private UserService _userService;

        public RegisterUserCommand(UserService userService)
        {
            _userService = userService;
        }

        public void Execute(User user)
        {
            Console.Write("Введіть ім'я користувача: ");
            var userName = Console.ReadLine();
            Console.Write("Введіть пароль: ");
            var password = Console.ReadLine();
            _userService.RegisterUser(userName, password);
        }

        public string GetCommandInfo()
        {
            return "Реєстрація нового користувача";
        }
    }
}