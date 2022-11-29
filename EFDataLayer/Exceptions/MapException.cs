using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLayer.Exceptions
{
    public class MapException : Exception
    {
        public MapException(string message) : base(message)
        {

        }

        public MapException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
