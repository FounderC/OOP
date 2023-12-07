namespace Лаб3.Simulation.GameAccounts
{
    public class WinningStreakGameAccount : GameAccount
    {
        private int consecutiveWins;

        public WinningStreakGameAccount(string userName, int initialRating) : base(userName, initialRating)
        {
            consecutiveWins = 0;
        }

        protected override int CalculateRatingForWin(int gameRating)
        {
            consecutiveWins++;
            var bonus = 0;
            if (consecutiveWins > 1)
            {
                bonus = consecutiveWins * 50;
            }
            return gameRating + bonus;
        }

        protected override int CalculateRatingForLoss(int gameRating)
        {
            consecutiveWins = 0;
            return gameRating;
        }

        public override string GetAccountType()
        {
            return "З бонусами за серію перемог";
        }
    }
}