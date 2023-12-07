using System;
using Лаб4.Repository.Base;

namespace Лаб4.Commands
{
    public class DisplayGamesCommand : ICommand
    {
        private GameRepository _gameRepository;

        public DisplayGamesCommand(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void Execute()
        {
            Console.WriteLine("Список усіх ігор:");
            
            foreach (var gameEntity in _gameRepository.ReadAll())
            {
                Console.WriteLine(
                    $"ID гри {gameEntity.Id}, Рейтинг гри {gameEntity.GameRating}, Тип гри {gameEntity.GameType}, Тип аккаунта {gameEntity.AccountType}, Перемога: {gameEntity.IsWin}");
            }
        }

        public string GetCommandInfo()
        {
            return "Вивід списку ігор";
        }
    }
}