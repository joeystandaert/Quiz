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

        public void AddBulk()
        {
            this.repo.AddBulk();
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

            return this.repo.GetQuizQuestions(randomIds);
        }


    }
}
