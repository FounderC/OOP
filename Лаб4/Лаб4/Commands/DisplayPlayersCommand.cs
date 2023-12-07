using System;
using Лаб4.Repository.Base;


namespace Лаб4.Commands
{
    public class DisplayPlayersCommand : ICommand
    {
        private PlayerRepository _playerRepository;

        public DisplayPlayersCommand(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void Execute()
        {
            foreach (var player in _playerRepository.ReadAll())
            {
                Console.WriteLine($"ID гравця {player.Id}, Імя {player.UserName}, Текущий рейтинг {player.CurrentRating}, Кількість ігор гравця {player.GamesCount}");
            }
        }

        public string GetCommandInfo()
        {
            return "Список гравців";
        }
    }
}