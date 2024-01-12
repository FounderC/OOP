using System;

namespace Лаб1.Simulation
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            GameAccount player1 = new GameAccount("Гравець1", new Random().Next(1, 100));
            GameAccount player2 = new GameAccount("Гравець2", new Random().Next(1, 151));


            for (int i = 0; i < 2; i++)
            {
                int ratingForGame = new Random().Next(1, 200);
                bool playerWins = new Random().Next(2) == 0;

                if (playerWins)
                {
                    player1.WinGame(player2.GetUserName(), ratingForGame);
                    player2.LoseGame(player1.GetUserName(), ratingForGame);
                }
                else
                {
                    player1.LoseGame(player2.GetUserName(), ratingForGame);
                    player2.WinGame(player1.GetUserName(), ratingForGame);
                }
            }

            player1.GetStats();
            Console.WriteLine();
            player2.GetStats();
        }
    }
}