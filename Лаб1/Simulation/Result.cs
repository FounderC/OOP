namespace Лаб1.Simulation
{
    public class Result
    {
        public string OpponentName { get; }
        public bool Victory { get; }
        public int RatingChange { get; }

        public Result(string opponentName, bool victory, int changeRating)
        {
            OpponentName = opponentName;
            Victory = victory;
            RatingChange = changeRating;
        }
    }
}