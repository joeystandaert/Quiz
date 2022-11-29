using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using EFDataLayer.Exceptions;
using EFDataLayer.Repositories;

namespace DataLayerProvider
{
    public class QuizRepositories
    {
        public IPlayerRepository PlayerRepository { get; }
        public IQuestionRepository QuestionRepository { get; }
        public IAnswerRepository AnswerRepository { get; }
        public IGameRepository GameRepository { get; }

        public QuizRepositories(string connectionString, RepositoryType repositoryType)
        {
            try
            {
                switch (repositoryType)
                {
                    case RepositoryType.EFCore:
                        PlayerRepository = new PlayerRepositoryEF(connectionString);
                        QuestionRepository = new QuestionRepository(connectionString);
                        AnswerRepository = new AnswerRepository(connectionString);
                        GameRepository = new GameRepository(connectionString);
                        break;
                    default: throw new QuizDataLayerFactoryException("GetRepository");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
