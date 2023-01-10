using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLayer.Models
{
    public class GameEF
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public PlayerEF Player{get;set;}
       
        [Required]
        public int Score { get;set;}
        [Required]
        public DateTime Date { get;set;}

        public GameEF()
        {

        }

        public GameEF(int id, PlayerEF player,  int score, DateTime date)
        {
            Id = id;
            Player = player;
           
            Score = score;
            Date = date;
        }
    }
}
