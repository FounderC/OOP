using System;
using Лаб4.Entities;
using Лаб4.Repository.Base;

namespace Лаб4.Commands
{
    public class CreatePlayerCommand : ICommand
    {
        private PlayerRepository _playerRepository;

        public CreatePlayerCommand(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void Execute()
        {
            var newPlayer = new PlayerEntity();
            _playerRepository.Create(newPlayer);

            Console.WriteLine($"Гравець був успішно створений");
        }

        public string GetCommandInfo()
        {
            return "Створити гравця";
        }
    }
}