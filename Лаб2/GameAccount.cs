using System;
using System.Collections.Generic;

namespace Лаб2
{
    abstract class GameAccount : Simulation
    {
        protected string UserName;
        protected int CurrentRating;
        protected int GamesCount;
        protected List<Result> history;

        public GameAccount(string UserName, int InitialRating)
        {
            SetUserName(UserName);
            if (InitialRating < 1)
            {
                throw new ArgumentException("Рейтинг повинен бути більшим або дорівнює 1 ");
            }
            CurrentRating = InitialRating;
            GamesCount = 0;
            history = new List<Result>();
        }

        public abstract int RatingCalculatorWin(int GameRating);
        public abstract int RatingCalculatorLoss(int GameRating);

        public void WinGame(GameAccount opponent, int GameRating)
        {
            int ChangeRating = RatingCalculatorWin(GameRating);
            CurrentRating += ChangeRating;
            GamesCount++;
            history.Add(new Result(opponent.GetUserName(), true, ChangeRating));
        }

        public void LoseGame(GameAccount opponent, int GameRating)
        {
            int ChangeRating = RatingCalculatorLoss(GameRating);
            CurrentRating -= ChangeRating;
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }

            GamesCount++;
            history.Add(new Result(opponent.GetUserName(), false, ChangeRating));
        }

        public void GetStats()
        {
            Console.WriteLine($"Статистика {UserName}:");
            for (int i = 0; i < history.Count; i++)
            {
                var result = history[i];
                string output = result.Victory ? "перемога" : "поразка";
                Console.WriteLine($"Гра #{i + 1}: Проти {result.OpponentName}, Результат: {output}, Зміна рейтингу: {result.ChangeRating}");
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
}
