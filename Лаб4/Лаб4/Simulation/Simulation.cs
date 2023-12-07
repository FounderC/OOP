using System;
using Лаб4.Repository.Base;
using Лаб4.Commands;

namespace Лаб4.Simulation
{
    public abstract class Simulation
    {
        private static DbContext.DbContext _dbContext = new DbContext.DbContext();
        private static PlayerRepository _playerRepository = new PlayerRepository(_dbContext);
        private static GameRepository _gameRepository = new GameRepository(_dbContext);
        private static GameFactory _gameFactory = new GameFactory();
        private static CommandManager _commandManager = new CommandManager();

        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            _commandManager.AddCommand(new CreatePlayerCommand(_playerRepository));
            _commandManager.AddCommand(new DisplayPlayersCommand(_playerRepository));
            _commandManager.AddCommand(new DeletePlayerCommand(_playerRepository));
            _commandManager.AddCommand(new EditPlayerCommand(_playerRepository));
            _commandManager.AddCommand(new DisplayPlayerGamesCommand(_playerRepository, _gameRepository));
            _commandManager.AddCommand(new DisplayGamesCommand(_gameRepository));
            _commandManager.AddCommand(new EditGameCommand(_gameRepository));
            _commandManager.AddCommand(new DeleteGameCommand(_gameRepository));
            _commandManager.AddCommand(new StartGameCommand(_playerRepository, _gameRepository, _gameFactory));

            Start();
        }

        private static void Start()
        {
            while (true)
            {
                Console.WriteLine("Запуск:");
                _commandManager.DisplayCommands();

                var startChoice = GetChoice(1, _commandManager.Commands.Count);
                _commandManager.ExecuteCommand(startChoice - 1);
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