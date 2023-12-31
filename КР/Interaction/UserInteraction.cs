using System;
using КР.Commands;
using КР.Commands.Managers;
using КР.Models;
using КР.Initializers;

namespace КР.Interaction
{
    public class UserInteraction
    {
        private static CommandManager _commandManager = new CommandManager();

        private static ProductInitializer _productInitializer =
            new ProductInitializer(ServicesInitializer.ProductService);

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            _productInitializer.InitializeProducts();

            _commandManager.AddCommand(new RegisterUserCommand(ServicesInitializer.UserService));
            _commandManager.AddCommand(new LoginCommand(ServicesInitializer.UserService));
            _commandManager.AddCommand(new LogoutCommand());
            _commandManager.AddCommand(new TopUpBalanceCommand(ServicesInitializer.UserService));
            _commandManager.AddCommand(new CheckBalanceCommand());
            _commandManager.AddCommand(new DisplayProductsCommand(ServicesInitializer.ProductService));
            _commandManager.AddCommand(new BuyProductCommand(ServicesInitializer.OrderService,
                ServicesInitializer.ProductService));
            _commandManager.AddCommand(new DisplayOrderHistoryCommand(ServicesInitializer.OrderService));
            Start();
        }

        private static void Start()
        {
            User currentUser = null;

            while (true)
            {
                Console.WriteLine("Запуск:");
                _commandManager.DisplayCommands();

                var startChoice = GetChoice(1, _commandManager.Commands.Count);
                if (startChoice == 2)
                {
                    var loginCommand = (LoginCommand)_commandManager.Commands[startChoice - 1];
                    loginCommand.Execute(currentUser);
                    currentUser = loginCommand.LoggedInUser;
                }
                else if (startChoice == 3)
                {
                    _commandManager.ExecuteCommand(startChoice - 1, currentUser);
                    currentUser = null;
                }
                else
                {
                    _commandManager.ExecuteCommand(startChoice - 1, currentUser);
                }
            }
        }

        private static int GetChoice(int minValue, int maxValue)
        {
            int choice;
            while (true)
            {
                Console.Write($"Введіть число від {minValue} до {maxValue}: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue)
                {
                    break;
                }

                Console.WriteLine("Некоректне введення. Спробуйте ще раз.");
            }

            return choice;
        }
    }
}