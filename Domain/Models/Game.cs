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
        public List<Question> Questions { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public Game(int id, Player player, List<Question> questions, int score, DateTime date)
        {
            Id = id;
            Player = player;
            Questions = questions;
            Score = score;
            Date = date;
        }
    }
}
