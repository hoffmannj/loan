using System;

namespace Calculator.Exceptions
{
    internal class ReaderException : Exception
    {
        public ReaderException(string message)
            : base(message)
        {}
    }
}
