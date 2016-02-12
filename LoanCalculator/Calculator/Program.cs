using Calculator.Exceptions;
using Calculator.Helper;
using Calculator.Implementation;
using Calculator.Interfaces;
using Calculator.Model;
using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameterParser = new ParameterParser();
            var parameters = parameterParser.ParseParameters(args);
            if (parameters == null)
            {
                WriteUsage();
                return;
            }

            try
            {
                List<Lender> lenders = null;
                using (IReader reader = new CsvReader())
                {
                    var collector = new DataCollector(reader);
                    lenders = collector.Collect(parameters.FileName);
                }
                var loanCalculator = new LoanCalculator();
                var result = loanCalculator.CalculateLoan(lenders, parameters.TargetAmount, 3);
                if (result == null)
                {
                    Console.WriteLine("It's not possible to provide a quote");
                }
                else
                {
                    PrintLending(result);
                }
            }
            catch (ReaderException rEx)
            {
                Console.WriteLine("Error during reading input: {0}", rEx.Message);
            }
            catch (DataParsingException dpEx)
            {
                Console.WriteLine("Error during parsing data: {0}", dpEx.Message);
            }
            catch (CalculatorException cEx)
            {
                Console.WriteLine("Error during calculation: {0}", cEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Uncategorized error: {0}", ex.Message);
            }
        }

        static void WriteUsage()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("{0} <market_file> <loan_amount>",
                System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase));
            Console.WriteLine();
        }

        static void PrintLending(Lending lending)
        {
            Console.WriteLine("Requested amount: £{0}", lending.Amount);
            Console.WriteLine("Rate: {0:0.0}%", lending.Rate * 100);
            Console.WriteLine("Monthly repayment: £{0:0.00}", lending.MonthlyAmount);
            Console.WriteLine("Total repayment: £{0:0.00}", lending.TotalAmount);
        }
    }
}
