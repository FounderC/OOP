namespace Лаб2
{
    class StandardGame : Game
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