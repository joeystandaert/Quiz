using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class PlayerService
    {
        IPlayerRepository repo;
        public PlayerService(IPlayerRepository repo) 
        {
            this.repo = repo;
        }

        public List<Player> GetAll()
        {
            return this.repo.GetAll();
        }

        public bool IsPlayerNameAvailable(string name)
        {
            return this.repo.IsPlayerNameAvailable(name);   
        }

        public void Add(string name)
        {
            this.repo.Add(name);
        }

        public void Delete(string name)
        {
            this.repo.Delete(name);
        }
    }
}
