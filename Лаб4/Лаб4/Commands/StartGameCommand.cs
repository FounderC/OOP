using System;
using Лаб4.Entities;
using Лаб4.Repository.Base;
using Лаб4.Simulation;
using Лаб4.Simulation.GameType;

namespace Лаб4.Commands
{
    public class StartGameCommand : ICommand
    {
        private PlayerRepository _playerRepository;
        private GameRepository _gameRepository;
        private GameFactory _gameFactory;

        public StartGameCommand(PlayerRepository playerRepository, GameRepository gameRepository,
            GameFactory gameFactory)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
            _gameFactory = gameFactory;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть ID першого гравця");
            var player1Id = int.Parse(Console.ReadLine() ?? string.Empty);
            var player1 = _playerRepository.ReadById(player1Id);

            Console.WriteLine("Введіть ID другого гравця");
            var player2Id = int.Parse(Console.ReadLine() ?? string.Empty);
            var player2 = _playerRepository.ReadById(player2Id);

            Console.WriteLine("Виберіть тип аккаунта:");
            Console.WriteLine("1. Стандартний аккаунт");
            Console.WriteLine("2. Аккаунт зі зменшеними втратами");
            Console.WriteLine("3. Аккаунт з бонусами за серію перемог");
            var accountTypeChoice = GetChoice(1, 3);

            Console.WriteLine("Виберіть тип гри:");
            Console.WriteLine("1. Стандартна гра");
            Console.WriteLine("2. Тренувальна гра");
            Console.WriteLine("3. Гра з одним гравцем");
            var gameTypeChoice = GetChoice(1, 3);

            var player1Account = CreatePlayer(_gameFactory, accountTypeChoice, player1.UserName, player1.CurrentRating);
            var player2Account = CreatePlayer(_gameFactory, accountTypeChoice, player2.UserName, player2.CurrentRating);

            Console.WriteLine("\nСимуляція гри...");

            for (var i = 0; i < 1; i++)
            {
                var gameRating = new Random().Next(1, 255);
                var game = CreateGame(gameTypeChoice, gameRating);

                player1Account.WinGame(player2Account, game.GetGameRating());
                player2Account.LoseGame(player1Account, game.GetGameRating());

                player1.CurrentRating = player1Account.CurrentRating;
                player1.GamesCount = player1Account.GamesCount;
                _playerRepository.Update(player1);

                player2.CurrentRating = player2Account.CurrentRating;
                player2.GamesCount = player2Account.GamesCount;
                _playerRepository.Update(player2);

                var gameEntity = new GameEntity
                {
                    GameRating = gameRating, PlayerId = player1Id, GameType = game.GetGameType(),
                    AccountType = player1Account.GetAccountType()
                };
                _gameRepository.Create(gameEntity);
            }

            Console.WriteLine("\nСтатистика гравців після симуляції:");
            Console.WriteLine();
            player1Account.GetStats();
            Console.WriteLine();
            player2Account.GetStats();

            Console.WriteLine("Гра створена");
        }

        public string GetCommandInfo()
        {
            return "Почати гру";
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

        private static GameAccount CreatePlayer(GameFactory factory, int accountTypeChoice, string userName,
            int initialRating)
        {
            switch (accountTypeChoice)
            {
                case 1:
                    return GameFactory.CreateStandardGameAccount(userName, initialRating);
                case 2:
                    return GameFactory.CreateReducedLossGameAccount(userName, initialRating);
                case 3:
                    return GameFactory.CreateWinningStreakGameAccount(userName, initialRating);
                default:
                    throw new ArgumentException("Некоректний вибір типу аккаунта.");
            }
        }

        private static Game CreateGame(int gameTypeChoice, int rating)
        {
            switch (gameTypeChoice)
            {
                case 1:
                    return new StandardGame(rating);
                case 2:
                    return new TrainingGame();
                case 3:
                    return new SoloGame(rating);
                default:
                    throw new ArgumentException("Некоректний вибір типу гри.");
            }
        }
    }
}