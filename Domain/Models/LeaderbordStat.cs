using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class LeaderbordStat
    {
        public Player Player { get; set; }
        public int GamesPlayed { get; set; }
        public int MaxScore { get; set; }

        public LeaderbordStat(Player player, int gamesPlayed, int maxScore)
        {
            Player = player;
            GamesPlayed = gamesPlayed;
            MaxScore = maxScore;    
        }
    }
}
