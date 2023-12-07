using System;
using Лаб4.Repository.Base;

namespace Лаб4.Commands
{
    public class DeletePlayerCommand : ICommand
    {
        private PlayerRepository _playerRepository;

        public DeletePlayerCommand(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть ID гравця");
            var answer = Console.ReadLine();

            if (!int.TryParse(answer, out var id))
            {
                Console.WriteLine("Такого гравця не існує");
            }

            var getPlayer = _playerRepository.ReadById(id);

            if (getPlayer == default)
            {
                Console.WriteLine("Такого гравця не існує");
            }

            PlayerRepository.Delete(id);
            Console.WriteLine("Ви видалили гравця");
        }

        public string GetCommandInfo()
        {
            return "Видалити гравця";
        }
    }
}