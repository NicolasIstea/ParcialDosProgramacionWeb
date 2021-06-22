using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class ValidationPagoException : Exception
    {
        public ValidationPagoException(string message) : base(message: message)
        {

        }
    }
}
