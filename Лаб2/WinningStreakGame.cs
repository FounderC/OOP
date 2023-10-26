namespace Лаб2
{
    class WinningStreakGame : GameAccount
    {
        private int consecutiveWins;

        public WinningStreakGame(string UserName, int InitialRating) : base(UserName, InitialRating)
        {
            consecutiveWins = 0;
        }

        public override int RatingCalculatorWin(int GameRating)
        {
            consecutiveWins++;
            int bonus = consecutiveWins;
            return GameRating + bonus;
        }

        public override int RatingCalculatorLoss(int GameRating)
        {
            consecutiveWins = 0;
            return GameRating;
        }
    }
}
