using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGameRepository
    {
        public void AddGame(Game game);
        public void GetGamebyId(int id);
        public List<Game> GetAll();

        public List<LeaderbordStat> GetLeaderbordStats();

    }
}
