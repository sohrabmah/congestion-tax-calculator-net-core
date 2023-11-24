using System;

namespace Core.Exceptions
{
    public class NotFoundExeption : Exception
    {

        public NotFoundExeption()
            : base()
        {
        }

        public NotFoundExeption(string message)
            : base(message)
        {
        }

        public NotFoundExeption(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NotFoundExeption(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
