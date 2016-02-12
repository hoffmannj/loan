using Calculator.Model;
using System;

namespace Calculator.Helper
{
    internal class ParameterParser
    {
        public ProgramParameters ParseParameters(string[] args)
        {
            if (args.Length != 2)
            {
                return null;
            }

            var fileName = args[0];
            decimal targetAmount = -1;
            if (!decimal.TryParse(args[1], out targetAmount))
            {
                Console.WriteLine("'loan_amount' is not valid!");
                return null;
            }

            return new ProgramParameters
            {
                FileName = fileName,
                TargetAmount = targetAmount
            };
        }
    }
}
