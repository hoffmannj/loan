using Calculator.Exceptions;
using Calculator.Model;

namespace Calculator.Helper
{
    internal class DataParser
    {
        public Lender Parse(string[] data)
        {
            var lender = new Lender(string.Empty, 0, 0);

            if (!CheckLength(data)) return null;
            if (!CheckName(data, lender)) return null;
            if (!CheckRate(data, lender)) return null;
            if (!CheckAmount(data, lender)) return null;

            return lender;
        }

        private bool CheckLength(string[] data)
        {
            if (data.Length != 3)
            {
                throw new DataParsingException(string.Format("Wrong format in data file. Line: {0}", string.Join(",", data)));
            }
            return true;
        }

        private bool CheckName(string[] data, Lender lender)
        {
            if (string.IsNullOrEmpty(data[0]))
            {
                throw new DataParsingException(string.Format("Name is missing in data file. Line: {0}", string.Join(",", data)));
            }
            lender.Name = data[0];
            return true;
        }

        private bool CheckRate(string[] data, Lender lender)
        {
            decimal rate;
            if (!decimal.TryParse(data[1], out rate))
            {
                throw new DataParsingException(string.Format("Rate field can't be parsed. Line: {0}", string.Join(",", data)));
            }
            lender.Rate = rate;
            return true;
        }

        private bool CheckAmount(string[] data, Lender lender)
        {
            decimal amount;
            if (!decimal.TryParse(data[2], out amount))
            {
                throw new DataParsingException(string.Format("Amount field can't be parsed. Line: {0}", string.Join(",", data)));
            }
            lender.Available = amount;
            return true;
        }
    }
}
