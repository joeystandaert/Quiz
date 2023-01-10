﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Sentence { get; set; }
        public bool IsCorrect { get; set; }

        public Answer()
        {

        }
        public Answer(int id, string sentence, bool isCorrect)
        {
            Id = id;
            Sentence = sentence;
            this.IsCorrect = isCorrect;
        }
    }
}
