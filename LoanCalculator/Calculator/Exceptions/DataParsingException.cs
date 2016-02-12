using System;

namespace Calculator.Exceptions
{
    internal class DataParsingException : Exception
    {
        public DataParsingException(string message)
            : base(message)
        { }
    }
}
