using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerProvider
{
    public class QuizDataLayerFactory
    {
        public static QuizRepositories GetRepositories(string connectionString, RepositoryType repositoryType)
        {
            return new QuizRepositories(connectionString, repositoryType);
        }
    }
}
