using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerProvider
{
    public class QuizDataLayerFactoryException: Exception
    {
        public QuizDataLayerFactoryException(string message) : base(message)
        {
        }

        public QuizDataLayerFactoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
