using Calculator.Helper;
using Calculator.Implementation;
using Calculator.Interfaces;
using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var lenders = new List<Lender>();

            using (IReader reader = new CsvReader())
            {
                var parser = new DataParser();
                if (reader.Open(parameters.FileName))
                {
                    string[] data;
                    while ((data = reader.ReadData()) != null)
                    {
                        var lender = parser.Parse(data);
                        if (lender != null) lenders.Add(lender);
                    }
                }
                else
                {
                    Console.WriteLine("Couldn't open the input.");
                }
            }
        }

        static void WriteUsage()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("{0} <market_file> <loan_amount>",
                System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase));
            Console.WriteLine();
        }
    }
}
