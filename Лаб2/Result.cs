namespace Лаб2
{
    class Result
    {
        public string OpponentName { get; }
        public bool Victory { get; }
        public int RatingChange { get; }

        public Result(string opponentName, bool victory, int ratingChange)
        {
            OpponentName = opponentName;
            Victory = victory;
            RatingChange = ratingChange;
        }
    }
}