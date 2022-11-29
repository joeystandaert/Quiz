using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace EFDataLayer.Repositories
{
    public class GameRepository : IGameRepository
    {
        string connectionString;
        public GameRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
