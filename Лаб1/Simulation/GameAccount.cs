using System;
using System.Collections.Generic;

namespace Лаб1.Simulation
{
    public class GameAccount
    {
        private string _userName;
        private int _currentRating;
        private int _gamesCount;
        private readonly List<Result> _history;

        public GameAccount(string userName, int startRating)
        {
            SetUserName(userName);
            if (startRating < 1)
            {
                throw new ArgumentException("Рейтинг менше 1");
            }

            _currentRating = startRating;
            _gamesCount = 0;
            _history = new List<Result>();
        }

        public void WinGame(string opponentName, int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentException("Рейтинг на який грають не може бути від'ємним");
            }

            _currentRating += rating;
            _gamesCount++;
            _history.Add(new Result(opponentName, true, rating));
        }

        public void LoseGame(string opponentName, int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentException("Рейтинг на який грають не може бути від'ємним");
            }

            _currentRating -= rating;
            if (_currentRating < 1)
            {
                _currentRating = 1;
            }

            _gamesCount++;
            _history.Add(new Result(opponentName, false, rating));
        }

        public void GetStats()
        {
            Console.WriteLine($"Статистика {_userName}:");
            for (int i = 0; i < _history.Count; i++)
            {
                var result = _history[i];
                string output = result.Victory ? "перемога" : "поразка";
                Console.WriteLine(
                    $"Гра #{i + 1}: Проти {result.OpponentName}, Результат: {output}, Рейтинг: {result.RatingChange}");
            }

            Console.WriteLine($"Загальна кількість ігор: {_gamesCount}, Поточний рейтинг: {_currentRating}");
        }

        public string GetUserName()
        {
            return _userName;
        }

        private void SetUserName(string value)
        {
            _userName = value;
        }
    }
}