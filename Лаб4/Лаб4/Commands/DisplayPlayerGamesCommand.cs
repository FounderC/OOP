using System;
using Лаб4.Repository.Base;
using System.Linq;

namespace Лаб4.Commands
{
    public class DisplayPlayerGamesCommand : ICommand
    {
        private PlayerRepository _playerRepository;
        private GameRepository _gameRepository;

        public DisplayPlayerGamesCommand(PlayerRepository playerRepository, GameRepository gameRepository)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть ID гравця");
            var playerId = int.Parse(Console.ReadLine() ?? string.Empty);
            var selectedPlayer = _playerRepository.ReadById(playerId);
            
            if (selectedPlayer == null)
            {
                Console.WriteLine("Такого гравця не існує");
                return;
            }
            
            Console.WriteLine($"Список ігор гравця {selectedPlayer.UserName}:");
            
            var games = _gameRepository.ReadAll().Where(game => game.PlayerId == playerId);
            foreach (var game in games)
            {
                Console.WriteLine(
                    $"ID гри {game.Id}, Рейтинг гри {game.GameRating}, Тип гри {game.GameType}, Тип аккаунта {game.AccountType}, Перемога: {game.IsWin}");
            }
        }

        public string GetCommandInfo()
        {
            return "Вивід списку ігор гравця";
        }
    }
}