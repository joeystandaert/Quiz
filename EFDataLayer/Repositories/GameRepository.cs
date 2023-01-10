using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using EFDataLayer.Mappers;
using EFDataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataLayer.Repositories
{
    public class GameRepository : IGameRepository
    {
        private QuizContext _dbContext;
        public GameRepository(QuizContextFactory ctxFactory)
        {
            this._dbContext = ctxFactory.Create();
        }

        public void AddGame(Game game)
        {
            _dbContext.Game.Add(MapGame.MapToDB(game, _dbContext));
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }

        public List<Game> GetAll()
        {
            List<GameEF> games = _dbContext.Game.ToList();
            return games.Select(g => MapGame.MapToDomain(g)).ToList();
        }

        public void GetGamebyId(int id)
        {
            throw new NotImplementedException();
        }

        public List<LeaderbordStat> GetLeaderbordStats()
        {
            List<GameEF> games = _dbContext.Game.Include(g => g.Player).ToList();
            return MapLeaderbord.MapToDomain(games).OrderByDescending(ls => ls.MaxScore).ToList();
        }
    }
}
