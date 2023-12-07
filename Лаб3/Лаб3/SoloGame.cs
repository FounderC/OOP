namespace Лаб3
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
        public override string GetGameType()
        {
            return "Одиночна гра";
        }
    }
}