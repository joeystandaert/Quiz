using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IQuestionRepository
    {
        
        public void AddBulk();

        public List<Question> GetQuizQuestions(List<int> ids);

        public void GetQuestionById(int id);

        public void AddQuestion(string senctence);

        public List<int> GetQuestionIds();

    }
}
