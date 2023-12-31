using System;
using КР.Commands.Base;
using КР.Models;

namespace КР.Commands
{
    public class LogoutCommand : ICommand
    {
        public void Execute(User user)
        {
            Console.WriteLine("Ви вийшли з системи.");
        }

        public string GetCommandInfo()
        {
            return "Вихід з системи";
        }
    }
}