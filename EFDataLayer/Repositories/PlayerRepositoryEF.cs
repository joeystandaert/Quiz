using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace EFDataLayer.Repositories
{
    public class PlayerRepositoryEF : IPlayerRepository
    {
        string connectionString;
        public PlayerRepositoryEF(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
