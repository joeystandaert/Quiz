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
    public interface MapAnswer
    {
        public static AnswerEF MapToDB(Answer answer)
        {
			try
			{
				return new AnswerEF(answer.Id, answer.Sentence, answer.isCorrect);
			}
			catch (Exception ex)
			{
				throw new MapException("MapAnswer - MapToDB", ex);
			}
        }

		public static Answer MapToDomain(AnswerEF answer)
		{
			try
			{
				return new Answer(answer.Id, answer.Sentence, answer.IsCorrect);
			}
			catch (Exception ex)
			{
				throw new MapException("MapAnswer - MapToDomain",ex);
			}
		}
    }
}
