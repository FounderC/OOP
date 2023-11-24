namespace Лаб2
{
    public class StandardGame : Game
    {
        private int gameRating;

        public StandardGame(int rating)
        {
            gameRating = rating;
        }

        public override int GetGameRating()
        {
            return gameRating;
        }
    }
}