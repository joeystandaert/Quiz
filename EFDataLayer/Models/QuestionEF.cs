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
    [PrimaryKey(nameof(Id), nameof(Sentence))]
    public class QuestionEF
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Sentence { get; set; }
        [Required]
        public ICollection<AnswerEF> Answers { get; set; }

        public QuestionEF()
        {

        }

        public QuestionEF(int id, string sentence, ICollection<AnswerEF> answers)
        {
            Id = id;
            Sentence = sentence;
            Answers = answers;
        }
    }
}
