namespace Лаб2
{
    class StandardGame : GameAccount
    {
        public StandardGame(string UserName, int InitialRating) : base(UserName, InitialRating) { }

        public override int RatingCalculatorWin(int GameRating)
        {
            return GameRating;
        }

        public override int RatingCalculatorLoss(int GameRating)
        {
            return GameRating;
        }
    }
}
