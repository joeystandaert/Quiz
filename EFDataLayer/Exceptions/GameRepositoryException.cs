using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLayer.Exceptions
{
    public class GameRepositoryException : Exception
    {
        public GameRepositoryException(string message) : base(message)
        {
        }

        public GameRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
