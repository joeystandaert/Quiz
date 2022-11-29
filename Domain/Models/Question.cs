using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Sentence { get; set; }
        public List<Answer> Anwsers {get;set;}

        public Question(int id, string sentence, List<Answer> anwsers)
        {
            Id = id;
            Sentence = sentence;
            Anwsers = anwsers;
        }
    }
}
