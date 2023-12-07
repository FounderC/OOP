using System;
using Лаб4.Repository.Base;

namespace Лаб4.Commands
{
    public class DeleteGameCommand : ICommand
    {
        private GameRepository _gameRepository;

        public DeleteGameCommand(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть ID гри");
            var gameId = int.Parse(Console.ReadLine());
            _gameRepository.Delete(gameId);
            Console.WriteLine("Гру було успішно видалено");
        }

        public string GetCommandInfo()
        {
            return "Видалити гру";
        }
    }
}