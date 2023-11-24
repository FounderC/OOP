namespace Лаб2
{
    public class SoloGame : Game
    {
        private int playerRating;

        public SoloGame(int playerRating)
        {
            this.playerRating = playerRating;
        }

        public override int GetGameRating()
        {
            return playerRating;
        }
    }
}