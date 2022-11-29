using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using EFDataLayer.Exceptions;
using EFDataLayer.Models;

namespace EFDataLayer.Mappers
{
    public interface MapQuestion
    {
        public static QuestionEF MapToDB(Question question, QuizContext ctx)
        {
			try
			{
				List<AnswerEF> answers = ctx.Answer.Where(a => question.Anwsers.Select(a => a.Id).Contains(a.Id)).ToList();
				return new QuestionEF(question.Id, question.Sentence, answers);
			}
			catch (Exception ex)
			{
				throw new MapException("MapQuestion - MapToDB",ex);
			}
        }
		public static Question MapToDomain(QuestionEF question)
		{
			try
			{
				return new Question(question.Id, question.Sentence, question.Answers.Select(a => MapAnswer.MapToDomain(a)).ToList());
			}
			catch (Exception ex)
			{

				throw new MapException("MapQuestion - MapToDomain",ex);
			}
		}
    }
}
