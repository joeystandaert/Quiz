using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using EFDataLayer.Mappers;
using EFDataLayer.Models;

namespace EFDataLayer.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private QuizContext _dbContext;
        public PlayerRepository(QuizContextFactory ctxFactory)
        {
            this._dbContext = ctxFactory.Create();
        }

        public void Add(string name)
        {
            _dbContext.Player.Add(new Models.PlayerEF { Name = name });
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }

        public void Delete(string name)
        {
            _dbContext.ChangeTracker.Clear();
            PlayerEF player = _dbContext.Player.First(x => x.Name == name);
            _dbContext.Player.Remove(player);
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
            
        }

        public List<Player> GetAll()
        {
            List<PlayerEF> players = _dbContext.Player.ToList();
            return players.Select(p => MapPlayer.MapToDomain(p)).ToList();
        }

        public bool IsPlayerNameAvailable(string name)
        {
            PlayerEF player = _dbContext.Player.FirstOrDefault(x => x.Name == name);
            if (player == null) return true;
            return false;
        }
    }
}
