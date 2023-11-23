namespace Лаб2
{
    class StandardGameAccount : GameAccount
    {
        public StandardGameAccount(string userName, int initialRating) : base(userName, initialRating)
        {
        }

        public override int CalculateRatingForWin(int gameRating)
        {
            return gameRating;
        }

        public override int CalculateRatingForLoss(int gameRating)
        {
            return gameRating;
        }

        public override string GetAccountType()
        {
            return "Стандартний";
        }
    }
}