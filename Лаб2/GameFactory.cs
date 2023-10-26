namespace Лаб2
{
    class GameFactory
    {
        public GameAccount CreateStandardGame(string UserName, int InitialRating)
        {
            return new StandardGame(UserName, InitialRating);
        }

        public GameAccount CreateReducedLossGame(string UserName, int InitialRating)
        {
            return new ReducedLossGame(UserName, InitialRating);
        }

        public GameAccount CreateWinningStreakGame(string UserName, int InitialRating)
        {
            return new WinningStreakGame(UserName, InitialRating);
        }
    }
}
