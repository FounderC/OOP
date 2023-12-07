using Лаб3.DbContext.Entities;
using System.Collections.Generic;

namespace Лаб3.DbContext
{ 
    public class DbContext
    {
        public List<PlayerEntity> Players { get; set; }
        public List<GameEntity> Games { get; set; }

        public DbContext()
        {
            Players = new List<PlayerEntity>();
            Games = new List<GameEntity>();

            Players.Add(new PlayerEntity { Id = 1, UserName = "Гравець1", CurrentRating = 123, GamesCount = 0 });
            Players.Add(new PlayerEntity { Id = 2, UserName = "Гравець2", CurrentRating = 123, GamesCount = 0 });
        }
    }
}