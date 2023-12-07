using Лаб3.Simulation.GameAccounts;

namespace Лаб3.Simulation
{
    public class GameFactory
    {
        public GameAccount CreateStandardGameAccount(string userName, int initialRating)
        {
            return new StandardGameAccount(userName, initialRating);
        }

        public GameAccount CreateReducedLossGameAccount(string userName, int initialRating)
        {
            return new ReducedLossGameAccount(userName, initialRating);
        }

        public GameAccount CreateWinningStreakGameAccount(string userName, int initialRating)
        {
            return new WinningStreakGameAccount(userName, initialRating);
        }
    }
}