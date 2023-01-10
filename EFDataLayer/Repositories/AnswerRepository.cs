using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace EFDataLayer.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private QuizContext _dbContext;
        public AnswerRepository(QuizContextFactory ctxFactory)
        {
            this._dbContext = ctxFactory.Create();
        }

        public void GetByQuestionId(int questionId)
        {
            throw new NotImplementedException();
        }
    }
}
