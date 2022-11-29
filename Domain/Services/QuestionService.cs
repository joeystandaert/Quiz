using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Services
{
    public class QuestionService
    {
        IQuestionRepository repo;

        public QuestionService(IQuestionRepository repo)
        {
            this.repo = repo;
        }
    }
}
