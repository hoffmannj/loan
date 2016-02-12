using Calculator.Exceptions;
using Calculator.Model;

namespace Calculator.Helper
{
    internal class DataParser
    {
        public Lender Parse(string[] data)
        {
            var lender = new Lender(string.Empty, 0, 0);

            CheckLength(data);
            CheckName(data, lender);
            CheckRate(data, lender);
            CheckAmount(data, lender);

            return lender;
        }

        private void CheckLength(string[] data)
        {
            if (data.Length != 3)
            {
                throw new DataParsingException(string.Format("Wrong format in data file. Line: {0}", string.Join(",", data)));
            }
        }

        private void CheckName(string[] data, Lender lender)
        {
            if (string.IsNullOrEmpty(data[0]))
            {
                throw new DataParsingException(string.Format("Name is missing in data file. Line: {0}", string.Join(",", data)));
            }
            lender.Name = data[0];
        }

        private void CheckRate(string[] data, Lender lender)
        {
            decimal rate;
            if (!decimal.TryParse(data[1], out rate))
            {
                throw new DataParsingException(string.Format("Rate field can't be parsed. Line: {0}", string.Join(",", data)));
            }
            lender.Rate = rate;
        }

        private void CheckAmount(string[] data, Lender lender)
        {
            decimal amount;
            if (!decimal.TryParse(data[2], out amount))
            {
                throw new DataParsingException(string.Format("Amount field can't be parsed. Line: {0}", string.Join(",", data)));
            }
            lender.Available = amount;
        }
    }
}
