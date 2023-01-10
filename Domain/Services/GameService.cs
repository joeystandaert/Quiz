using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class GameService
    {
        IGameRepository repo;

        public GameService(IGameRepository repo)
        {
            this.repo = repo;
        }
        public void AddGame(Game game)
        {
            this.repo.AddGame(game);
        }

        public List<Game> GetAll()
        {
            return this.repo.GetAll();
        }

        public void GetGamebyId(int id)
        {
           this.repo.GetGamebyId(id);
        }

        public List<LeaderbordStat> GetLeaderbordStats()
        {
            return this.repo.GetLeaderbordStats();
        }
    }
}
