using System;

namespace Core.Exceptions
{
    public class NotValidValueExeption : Exception
    {
        public NotValidValueExeption(string name, object value)
            : base($"{value} is not a valid Value For {name}")
        {
        }
    }
}
