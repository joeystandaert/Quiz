using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPlayerRepository
    {
        public List<Player> GetAll();

        public bool IsPlayerNameAvailable(string name);

        public void Add(string name);
        public void Delete(string name);
        //naam is altijd uniek; daarom doen we dit op naam
    }
}
