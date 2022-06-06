using System;

namespace GimnasioException
{
    public class PersonaException : Exception
    {
        public PersonaException()
        {

        }

        public PersonaException(string message) : base(message)
        {

        }

        public PersonaException(string message, Exception innerException) : base(message, innerException)
        {

        }

    }
}
