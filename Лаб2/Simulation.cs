using System;

namespace Лаб2
{
    public class Simulation
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            GameFactory gameFactory = new GameFactory();

            Console.WriteLine("Виберіть тип гри:");
            Console.WriteLine("1. Стандартна гра");
            Console.WriteLine("2. Тренувальна гра");
            Console.WriteLine("3. Гра з одним гравцем");

            int gameTypeChoice = GetChoice(1, 3);

            Console.WriteLine("\nВиберіть тип аккаунта:");
            Console.WriteLine("1. Стандартний аккаунт");
            Console.WriteLine("2. Аккаунт зі зменшеними втратами");
            Console.WriteLine("3. Аккаунт з бонусами за серію перемог");

            int accountTypeChoice = GetChoice(1, 3);

            GameAccount player1 = CreatePlayer(gameFactory, accountTypeChoice, "Гравець1", new Random().Next(1, 255));
            GameAccount player2 = CreatePlayer(gameFactory, accountTypeChoice, "Гравець2", new Random().Next(1, 255));

            Console.WriteLine("\nСимуляція гри...");

            for (int i = 0; i < 5; i++)
            {
                Game game = CreateGame(gameTypeChoice, new Random().Next(1, 255));

                player1.WinGame(player2, game.GetGameRating());
                player2.WinGame(player1, game.GetGameRating());
                player2.LoseGame(player1, game.GetGameRating());
            }

            Console.WriteLine("\nСтатистика гравців після симуляції:");
            Console.WriteLine();
            player1.GetStats();
            Console.WriteLine();
            player2.GetStats();
        }

        static int GetChoice(int minValue, int maxValue)
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

        static GameAccount CreatePlayer(GameFactory factory, int accountTypeChoice, string userName, int initialRating)
        {
            switch (accountTypeChoice)
            {
                case 1:
                    return factory.CreateStandardGameAccount(userName, initialRating);
                case 2:
                    return factory.CreateReducedLossGameAccount(userName, initialRating);
                case 3:
                    return factory.CreateWinningStreakGameAccount(userName, initialRating);
                default:
                    throw new ArgumentException("Некоректний вибір типу аккаунта.");
            }
        }

        static Game CreateGame(int gameTypeChoice, int rating)
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