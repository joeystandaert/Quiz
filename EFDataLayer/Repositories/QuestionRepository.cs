using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using EFDataLayer.Mappers;
using EFDataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataLayer.Repositories
{


    public class QuestionRepository: IQuestionRepository
    {
        private QuizContext _dbContext;
        public QuestionRepository(QuizContextFactory ctxFactory)
        {
            this._dbContext = ctxFactory.Create();
        }

        public void AddBulk(List<Question> questions)
        {
            foreach (Question question in questions)
            {
                var efQuestion = MapQuestion.MapNewToDb(question);
                _dbContext.Question.Add(efQuestion);
            }
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }
        public void DeleteAllQuestions()
        {
            _dbContext.Answer.RemoveRange(_dbContext.Answer.ToArray());
            _dbContext.Question.RemoveRange(_dbContext.Question.ToArray());
        }

        public void AddQuestion(string sentence)
        {
            _dbContext.Question.Add(new Models.QuestionEF { Sentence = sentence });
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }

        public void GetQuestionById(int id)
        {
           //List<QuestionEF> questions = _dbContext.Question.ToList();
           // return questions.Where(q => q.Id.ToString() == id.ToString()).Select(x => MapQuestion.MapToDomain(x)).SingleOrDefault();
        }

        public List<Question> GetQuizQuestions(List<int> ids)
        {
            var questions = _dbContext.Question.Include(q => q.Answers).Where(q => ids.Contains(q.Id));
            return questions.Select(q => MapQuestion.MapToDomain(q)).ToList();
        }

        public List<int> GetQuestionIds()
        {
            return _dbContext.Question.Select(q => q.Id).ToList();
        }
    }
}
