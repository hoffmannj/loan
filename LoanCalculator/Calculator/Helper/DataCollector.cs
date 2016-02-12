using Calculator.Interfaces;
using Calculator.Model;
using System;
using System.Collections.Generic;

namespace Calculator.Helper
{
    internal class DataCollector
    {
        private IReader _reader;

        public DataCollector(IReader reader)
        {
            if (reader == null) throw new ArgumentNullException("reader");
            _reader = reader;
        }

        public List<Lender> Collect(string readerParameter)
        {
            var lenders = new List<Lender>();
            var parser = new DataParser();
            _reader.Open(readerParameter);
            string[] data;
            while ((data = _reader.ReadData()) != null)
            {
                var lender = parser.Parse(data);
                if (lender != null) lenders.Add(lender);
            }
            return lenders;
        }
    }
}
