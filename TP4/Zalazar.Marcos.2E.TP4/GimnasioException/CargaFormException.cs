using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GimnasioException
{
    public class CargaFormException : Exception
    {
        public CargaFormException()
        {

        }

        public CargaFormException(string message) : base(message)
        {

        }

        public CargaFormException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
