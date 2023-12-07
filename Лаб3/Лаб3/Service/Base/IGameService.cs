using System.Collections.Generic;
using Лаб3.DbContext.Entities;

namespace Лаб3.Service.Base
{
    public interface IGameService
    {
        void CreateGame(int gameRating);
        List<GameEntity> GetAllGames();
        GameEntity GetGameById(int gameId);
        void UpdateGame(GameEntity game);
        void DeleteGame(int gameId);
    }
}