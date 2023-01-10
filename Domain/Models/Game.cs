using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Game
    {
        public int Id { get; set; }
        public Player Player { get; set; }
   
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public Game()
        {

        }

        public Game(int id, Player player, int score, DateTime date)
        {
            Id = id;
            Player = player;
        
            Score = score;
            Date = date;
        }
    }
}
