﻿namespace Лаб4.Simulation.GameType
{
    public class SoloGame : Game
    {
        private int _playerRating;

        public SoloGame(int playerRating)
        {
            this._playerRating = playerRating;
        }

        public override int GetGameRating()
        {
            return _playerRating;
        }
        public override string GetGameType()
        {
            return "Одиночна гра";
        }
    }
}