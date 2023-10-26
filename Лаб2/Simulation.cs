using System;
using Лаб2;

class Simulation : GameFactory
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        GameFactory gameFactory = new GameFactory();
        GameAccount standardPlayer = gameFactory.CreateStandardGame("Гравець1", new Random().Next(1, 100));
        GameAccount reducedLossPlayer = gameFactory.CreateReducedLossGame("Гравець2", new Random().Next(1, 100));
        GameAccount winningStreakPlayer = gameFactory.CreateWinningStreakGame("Гравець3", new Random().Next(1, 100));

        for (int i = 0; i < 5; i++)
        {
            int GameRating = new Random().Next(1, 200);

            standardPlayer.WinGame(reducedLossPlayer, GameRating);
            reducedLossPlayer.LoseGame(standardPlayer, GameRating);
            winningStreakPlayer.WinGame(standardPlayer, GameRating);
            standardPlayer.LoseGame(winningStreakPlayer, GameRating);
        }
        standardPlayer.GetStats();
        Console.WriteLine();
        reducedLossPlayer.GetStats();
        Console.WriteLine();
        winningStreakPlayer.GetStats();
    }
}
