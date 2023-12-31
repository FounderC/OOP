using System;
using КР.Commands;
using КР.Commands.Managers;
using КР.Models;
using КР.Initializers;

namespace КР.Interaction
{
    public class UserInteraction
    {
        private CommandManager _commandManager;
        private ServicesInitializer _servicesInitializer;
        private ProductInitializer _productInitializer;

        public UserInteraction()
        {
            _servicesInitializer = new ServicesInitializer();
            _commandManager = new CommandManager();
            _productInitializer = new ProductInitializer(_servicesInitializer.ProductService);
        }

        public void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            _productInitializer.InitializeProducts();

            _commandManager.AddCommand(new RegisterUserCommand(_servicesInitializer.UserService));
            _commandManager.AddCommand(new LoginCommand(_servicesInitializer.UserService));
            _commandManager.AddCommand(new LogoutCommand());
            _commandManager.AddCommand(new TopUpBalanceCommand(_servicesInitializer.UserService));
            _commandManager.AddCommand(new CheckBalanceCommand());
            _commandManager.AddCommand(new DisplayProductsCommand(_servicesInitializer.ProductService));
            _commandManager.AddCommand(new BuyProductCommand(_servicesInitializer.OrderService,
                _servicesInitializer.ProductService));
            _commandManager.AddCommand(new DisplayOrderHistoryCommand(_servicesInitializer.OrderService));
            Start();
        }

        private void Start()
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

        private int GetChoice(int minValue, int maxValue)
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