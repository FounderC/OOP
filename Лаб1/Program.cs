using System;
using System.Collections.Generic;

class GameAccount
{
    private string UserName;
    private int CurrentRating;
    private int GamesCount;
    private List<Result> history;

    public GameAccount(string UserName, int StartRating)
    {
        SetUserName(UserName);
        if (StartRating < 1)
        {
            throw new ArgumentException("Рейтинг менше 1");
        }
        CurrentRating = StartRating;
        GamesCount = 0;
        history = new List<Result>();
    }

    public void WinGame(string opponentName, int Rating)
    {
        if (Rating < 0)
        {
            throw new ArgumentException("Рейтинг на який грають не може бути від'ємним");
        }

        CurrentRating += Rating;
        GamesCount++;
        history.Add(new Result(opponentName, true, Rating));
    }

    public void LoseGame(string opponentName, int Rating)
    {
        if (Rating < 0)
        {
            throw new ArgumentException("Рейтинг на який грають не може бути від'ємним");
        }

        CurrentRating -= Rating;
        if (CurrentRating < 1)
        {
            CurrentRating = 1;
        }

        GamesCount++;
        history.Add(new Result(opponentName, false, Rating));
    }

    public void GetStats()
    {
        Console.WriteLine($"Статистика {UserName}:");
        for (int i = 0; i < history.Count; i++)
        {
            var result = history[i];
            string output = result.Victory ? "перемога" : "поразка";
            Console.WriteLine($"Гра #{i + 1}: Проти {result.OpponentName}, Результат: {output}, Рейтинг: {result.RatingChange}");
        }
        Console.WriteLine($"Загальна кількість ігор: {GamesCount}, Поточний рейтинг: {CurrentRating}");
    }

    public string GetUserName()
    {
        return UserName;
    }
    private void SetUserName(string value)
    {
        UserName = value;
    }
}

class Result
{
    public string OpponentName { get; }
    public bool Victory { get; }
    public int RatingChange { get; }

    public Result(string opponentName, bool victory, int ChangeRating)
    {
        OpponentName = opponentName;
        Victory = victory;
        RatingChange = ChangeRating;
    }
}

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