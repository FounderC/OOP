namespace Лаб2
{
    class Result
    {
        public string OpponentName { get; }
        public bool Victory { get; }
        public int ChangeRating { get; }

        public Result(string opponentName, bool victory, int changeRating)
        {
            OpponentName = opponentName;
            Victory = victory;
            ChangeRating = changeRating;
        }
    }
}
