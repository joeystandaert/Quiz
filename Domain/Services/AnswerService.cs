using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Services
{
    public class AnswerService
    {
        IAnswerRepository repo;
        public AnswerService(IAnswerRepository repo)
        {
            this.repo = repo;
        }

        public void GetByQuestionId(int questionId)
        {
             this.repo.GetByQuestionId(questionId);
        }
    }
}
