using System.Collections.Generic;
using Лаб3.DbContext.Entities;

namespace Лаб3.Repository.Base
{
    public interface IPlayerRepository
    {
        void Create(PlayerEntity player);
        List<PlayerEntity> ReadAll();
        PlayerEntity ReadById(int playerId);
        void Update(PlayerEntity player);
        void Delete(int playerId); 
    }
}