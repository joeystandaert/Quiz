using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class QuestionService
    {
        IQuestionRepository repo;

        public QuestionService(IQuestionRepository repo)
        {
            this.repo = repo;
        }

        public void AddBulk(List<Question> questions)
        {
            this.repo.AddBulk(questions);
        }

        public void AddQuestion(string sentence)
        {
           this.repo.AddQuestion(sentence);
        }
        public void GetQuestionById(int id)
        {
           this.repo.GetQuestionById(id);   
        }


        public List<Question> GetQuizQuestions()
        {
          var ids = this.repo.GetQuestionIds();
          List<int> randomIds = new List<int>();

            while (randomIds.Count < 10)
            {
                Random r = new Random();
                var generated = r.Next(0, ids.Count -1);
                var id = ids.ElementAt(generated);
                if (!randomIds.Contains(id))
                {
                    randomIds.Add(id);
                }
            }

            var questions = this.repo.GetQuizQuestions(randomIds);

            foreach (var question in questions)
            {
                var answersRandom = new Random();
                int n = question.Anwsers.Count;
                while (n > 1)
                {
                    n--;
                    int k = answersRandom.Next(n + 1);
                    var tempAnswer = question.Anwsers[k];
                    question.Anwsers[k] = question.Anwsers[n];
                    question.Anwsers[n] = tempAnswer;
                }
            }
            return questions;
        }

        public void DeleteAllQuestions()
        {
            this.repo.DeleteAllQuestions();
        }


    }
}
