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
        public ICollection<QuestionEF> Questions { get;set;}
        [Required]
        public int Score { get;set;}
        [Required]
        public DateTime Date { get;set;}

        public GameEF()
        {

        }

        public GameEF(int id, PlayerEF player, ICollection<QuestionEF> questions, int score, DateTime date)
        {
            Id = id;
            Player = player;
            Questions = questions;
            Score = score;
            Date = date;
        }
    }
}
