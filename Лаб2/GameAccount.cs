using System;
using System.Collections.Generic;

namespace Лаб2
{
    public abstract class GameAccount
    {
        protected string UserName;
        protected int CurrentRating;
        protected int GamesCount;
        protected List<Result> History;

        public GameAccount(string userName, int initialRating)
        {
            SetUserName(userName);
            if (initialRating < 1)
            {
                throw new ArgumentException("Рейтинг повинен бути більшим або дорівнювати 1.");
            }

            CurrentRating = initialRating;
            GamesCount = 0;
            History = new List<Result>();
        }

        public abstract int CalculateRatingForWin(int gameRating);

        public abstract int CalculateRatingForLoss(int gameRating);

        public void WinGame(GameAccount opponent, int gameRating)
        {
            int ratingChange = CalculateRatingForWin(gameRating);
            CurrentRating += ratingChange;
            GamesCount++;
            History.Add(new Result(opponent.GetUserName(), true, ratingChange));
        }

        public void LoseGame(GameAccount opponent, int gameRating)
        {
            int ratingChange = CalculateRatingForLoss(gameRating);
            CurrentRating -= ratingChange;
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }

            GamesCount++;
            History.Add(new Result(opponent.GetUserName(), false, ratingChange));
        }

        public void GetStats()
        {
            Console.WriteLine($"Статистика {UserName} ({GetAccountType()}):");
            for (int i = 0; i < History.Count; i++)
            {
                var result = History[i];
                string output = result.Victory ? "перемога" : "поразка";
                Console.WriteLine(
                    $"Гра #{i + 1}: Проти {result.OpponentName}, Результат: {output}, Зміна рейтингу: {result.RatingChange}");
            }

            Console.WriteLine($"Загальна кількість ігор: {GamesCount}, Поточний рейтинг: {CurrentRating}");
        }

        public string GetUserName()
        {
            return UserName;
        }

        public abstract string GetAccountType();

        private void SetUserName(string value)
        {
            UserName = value;
        }
    }
}