using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFDataLayer.Models
{
    [PrimaryKey(nameof(Id))]
    public class AnswerEF
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Sentence { get; set; }
        [Required]
        public bool IsCorrect { get; set; }

        public AnswerEF()
        {

        }

        public AnswerEF(int id, string sentence, bool isCorrect)
        {
            Id = id;
            Sentence = sentence;
            IsCorrect = isCorrect;
        }
    }
}
