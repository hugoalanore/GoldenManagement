using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Exceptions
{
    public class DALException : Exception
    {
        public DALException() : base() { }
        public DALException(string message) : base(message) { }
        public DALException(string message, Exception inner) : base(message, inner) { }
    }
}
