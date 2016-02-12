using Calculator.Interfaces;
using Calculator.Model;
using System.Collections.Generic;

namespace Calculator.Tests.Reader
{
    class FakeReader : IReader
    {
        private readonly List<Lender> _lenders = new List<Lender>
        {
            new Lender("Bob", 0.075m, 640),
            new Lender("Jane", 0.069m, 480),
            new Lender("Fred", 0.071m, 520),
            new Lender("Mary", 0.104m, 170),
            new Lender("John", 0.081m, 320),
            new Lender("Dave", 0.074m, 140),
            new Lender("Angela", 0.071m, 60)
        };
        private int _index = 0;

        public bool Open(string parameter)
        {
            return true;
        }

        public void Close()
        {}

        public string[] ReadData()
        {
            if (_index >= _lenders.Count) return null;
            var lender = _lenders[_index];
            ++_index;
            return new string[] { lender.Name, lender.Rate.ToString(), lender.Available.ToString() };
        }

        public void Dispose()
        {}
    }
}
