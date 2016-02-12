using System;

namespace Calculator.Exceptions
{
    internal class CalculatorException : Exception
    {
        public CalculatorException(string message)
            : base(message)
        { }
    }
}
