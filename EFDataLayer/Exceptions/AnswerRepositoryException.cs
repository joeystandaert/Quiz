using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLayer.Exceptions
{
    public class AnswerRepositoryException : Exception
    {
        public AnswerRepositoryException(string message) : base(message)
        {
        }

        public AnswerRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
