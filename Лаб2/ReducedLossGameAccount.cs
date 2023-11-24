namespace Лаб2
{
    public class ReducedLossGameAccount : GameAccount
    {
        public ReducedLossGameAccount(string userName, int initialRating) : base(userName, initialRating)
        {
        }

        public override int CalculateRatingForWin(int gameRating)
        {
            return gameRating;
        }

        public override int CalculateRatingForLoss(int gameRating)
        {
            return gameRating / 2;
        }

        public override string GetAccountType()
        {
            return "Зі зменшеними втратами";
        }
    }
}