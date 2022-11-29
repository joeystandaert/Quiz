using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLayer.Exceptions
{
    public class QuestionRepositoryException : Exception
    {
        public QuestionRepositoryException(string message) : base(message)
        {
        }

        public QuestionRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
