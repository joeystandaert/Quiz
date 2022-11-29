using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Services
{
    public class PlayerService
    {
        IPlayerRepository repo;
        public PlayerService(IPlayerRepository repo) 
        {
            this.repo = repo;
        }
    }
}
