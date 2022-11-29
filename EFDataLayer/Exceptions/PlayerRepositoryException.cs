using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLayer.Exceptions
{
    public class PlayerRepositoryException : Exception
    {
        public PlayerRepositoryException(string message) : base(message)
        {
        }

        public PlayerRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
