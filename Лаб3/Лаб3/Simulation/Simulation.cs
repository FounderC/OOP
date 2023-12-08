using System;
using Лаб3.DbContext.Entities;
using Лаб3.Repository;
using Лаб3.Simulation.GameType;
using Лаб3.Service.Base;
using Лаб3.Service;

namespace Лаб3.Simulation
{
    public abstract class Simulation
    {
        private static DbContext.DbContext _dbContext = new DbContext.DbContext();

        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Start();
        }

        private static void Start()
        {
            while (true)
            {
                Console.WriteLine("Запуск:");
                Console.WriteLine("1. Список гравців");
                Console.WriteLine("2. Створити гравця");
                Console.WriteLine("3. Видалити гравця");
                Console.WriteLine("4. Редагувати гравця");
                Console.WriteLine("5. Вивід списку ігор гравця");
                Console.WriteLine("6. Вивід списку ігор ");
                Console.WriteLine("7. Редагувати ігру ");
                Console.WriteLine("8. Видалити ігру ");
                Console.WriteLine("9. Почати гру ");

                var startChoice = GetChoice(1, 9);
                var playerRepository = new PlayerRepository(_dbContext);
                var gameRepository = new GameRepository(_dbContext);
                var playerEntity = new PlayerEntity();
                var gameFactory = new GameFactory();

                switch (startChoice)
                {
                    case 1:
                        foreach (var player in playerRepository.ReadAll())
                        {
                            Console.WriteLine(
                                $"ID гравця {player.Id}, Імя {player.UserName}, Текущий рейтинг {player.CurrentRating}, Кількість ігор гравця {player.GamesCount}");
                        }
                        continue;
                    
                    case 2:
                        PlayerRepository.Create(playerEntity);
                        Console.WriteLine("Ви створили гравця");
                        continue;
                    
                    case 3:
                        Console.WriteLine("Введіть ID гравця");
                        var answer = Console.ReadLine();

                        if (!int.TryParse(answer, out var id))
                        {
                            Console.WriteLine("Такого гравця не існує");
                            Start();
                        }

                        var getPlayer = playerRepository.ReadById(id);

                        if (getPlayer == default)
                        {
                            Console.WriteLine("Такого гравця не існує");
                            Start();
                        }

                        PlayerRepository.Delete(id);
                        Console.WriteLine("Ви видалили гравця");
                        continue;
                    
                    case 4:
                        Console.WriteLine("Введіть ID гравця");
                        answer = Console.ReadLine();

                        if (!int.TryParse(answer, out id))
                        {
                            Console.WriteLine("Такого гравця не існує");
                            Start();
                        }

                        getPlayer = playerRepository.ReadById(id);

                        if (getPlayer == default)
                        {
                            Console.WriteLine("Такого гравця не існує");
                            Start();
                        }

                        Console.WriteLine("Виберіть, що ви хочете змінити:");
                        Console.WriteLine("1. Ім'я гравця");
                        Console.WriteLine("2. Поточний рейтинг");
                        Console.WriteLine("3. Кількість ігор");

                        var editChoicePlayer = GetChoice(1, 3);

                        switch (editChoicePlayer)
                        {
                            case 1:
                                Console.WriteLine("Введіть нове ім'я гравця");
                                var newName = Console.ReadLine();
                                getPlayer.UserName = newName;
                                continue;
                            case 2:
                                Console.WriteLine("Введіть новий рейтинг гравця");
                                var newRating = int.Parse(Console.ReadLine());
                                getPlayer.CurrentRating = newRating;
                                continue;
                            case 3:
                                Console.WriteLine("Введіть нову кількість ігор гравця");
                                var newGamesCount = int.Parse(Console.ReadLine());
                                getPlayer.GamesCount = newGamesCount;
                                continue;
                        }

                        playerRepository.Update(getPlayer);
                        Console.WriteLine("Ви оновили гравця");
                        continue;

                    case 5:
                        Console.WriteLine("Введіть ID гравця");
                        var playerId = int.Parse(Console.ReadLine());
                        var selectedPlayer = playerRepository.ReadById(playerId);

                        if (selectedPlayer == null)
                        {
                            Console.WriteLine("Такого гравця не існує");
                            continue;
                        }

                        Console.WriteLine($"Список ігор гравця {selectedPlayer.UserName}:");

                        foreach (var game in gameRepository.ReadAll())
                        {
                            if (game.PlayerId == playerId)
                            {
                                Console.WriteLine(
                                    $"ID гри {game.Id}, Рейтинг гри {game.GameRating}, Тип гри {game.GameType}, Тип аккаунта {game.AccountType}, Перемога: {game.IsWin}");
                            }
                        }
                        continue;

                    case 6:
                        Console.WriteLine("Список усіх ігор:");

                        foreach (var gameEntity in gameRepository.ReadAll())
                        {
                            Console.WriteLine(
                                $"ID гри {gameEntity.Id}, Рейтинг гри {gameEntity.GameRating}, Тип гри {gameEntity.GameType}, Тип аккаунта {gameEntity.AccountType}, Перемога: {gameEntity.IsWin}");
                        }
                        continue;

                    case 7:
                        Console.WriteLine("Введіть ID гри");
                        var gameId = int.Parse(Console.ReadLine());
                        var selectedGame = gameRepository.ReadById(gameId);

                        if (selectedGame == null)
                        {
                            Console.WriteLine("Такої гри не існує");
                            continue;
                        }

                        Console.WriteLine("Виберіть, що ви хочете змінити:");
                        Console.WriteLine("1. Рейтинг гри");
                        Console.WriteLine("2. ID гравця");

                        var editChoiceGame = GetChoice(1, 2);

                        switch (editChoiceGame)
                        {
                            case 1:
                                Console.WriteLine("Введіть новий рейтинг гри");
                                var newRating = int.Parse(Console.ReadLine());
                                selectedGame.GameRating = newRating;
                                break;
                            case 2:
                                Console.WriteLine("Введіть новий ID гравця");
                                var newPlayerId = int.Parse(Console.ReadLine());
                                selectedGame.PlayerId = newPlayerId;
                                break;
                        }

                        gameRepository.Update(selectedGame);
                        Console.WriteLine("Ви оновили гру");
                        continue;

                    case 8:
                        Console.WriteLine("Введіть ID гри");
                        gameId = int.Parse(Console.ReadLine());
                        gameRepository.Delete(gameId);
                        Console.WriteLine("Ви видалили гру");
                        continue;

                    case 9:
                        Console.WriteLine("Введіть ID першого гравця");
                        var player1Id = int.Parse(Console.ReadLine());
                        var player1 = playerRepository.ReadById(player1Id);

                        Console.WriteLine("Введіть ID другого гравця");
                        var player2Id = int.Parse(Console.ReadLine());
                        var player2 = playerRepository.ReadById(player2Id);

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

                        var player1Account = CreatePlayer(gameFactory, accountTypeChoice, player1.UserName,
                            player1.CurrentRating);
                        var player2Account = CreatePlayer(gameFactory, accountTypeChoice, player2.UserName,
                            player2.CurrentRating);

                        Console.WriteLine("\nСимуляція гри...");

                        for (var i = 0; i < 1; i++)
                        {
                            var gameRating = new Random().Next(1, 255);
                            var game = CreateGame(gameTypeChoice, gameRating);

                            player1Account.WinGame(player2Account, game.GetGameRating());
                            player2Account.LoseGame(player1Account, game.GetGameRating());

                            player1.CurrentRating = player1Account.CurrentRating;
                            player1.GamesCount = player1Account.GamesCount;
                            playerRepository.Update(player1);

                            player2.CurrentRating = player2Account.CurrentRating;
                            player2.GamesCount = player2Account.GamesCount;
                            playerRepository.Update(player2);

                            var gameEntity = new GameEntity
                            {
                                GameRating = gameRating, PlayerId = player1Id, GameType = game.GetGameType(),
                                AccountType = player1Account.GetAccountType()
                            };
                            gameRepository.Create(gameEntity);
                        }

                        Console.WriteLine("\nСтатистика гравців після симуляції:");
                        Console.WriteLine();
                        player1Account.GetStats();
                        Console.WriteLine();
                        player2Account.GetStats();

                        Console.WriteLine("Гра створена");
                        continue;
                }
                break;
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

        static GameAccount CreatePlayer(GameFactory factory, int accountTypeChoice, string userName,
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