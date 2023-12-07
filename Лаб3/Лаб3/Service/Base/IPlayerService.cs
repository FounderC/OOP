using System.Collections.Generic;
using Лаб3.DbContext.Entities;

namespace Лаб3.Service.Base
{
    public interface IPlayerService
    {
        void CreatePlayer(string userName, int initialRating);
        List<PlayerEntity> GetAllPlayers();
        PlayerEntity GetPlayerById(int playerId);
        void UpdatePlayer(PlayerEntity player);
        void DeletePlayer(int playerId);
    }
}