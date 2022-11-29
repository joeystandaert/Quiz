using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Services
{
    public class GameService
    {
        IGameRepository repo;

        public GameService(IGameRepository repo)
        {
            this.repo = repo;
        }
    }
}
