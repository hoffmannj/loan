using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Implementation
{
    internal class CsvReader : IReader
    {
        private System.IO.StreamReader _reader;

        public bool Open(string parameter)
        {
            try
            {
                _reader = new System.IO.StreamReader(parameter);
                return true;
            }
            catch (Exception)
            {
                _reader = null;
                return false;
            }
        }

        public void Close()
        {
            if (_reader == null) return;
            _reader.Dispose();
            _reader = null;
        }

        public string[] ReadData()
        {
            AssertReader();
            var line = _reader.ReadLine();
            if (string.IsNullOrEmpty(line)) return null;
            return line.Split(',');
        }

        private void AssertReader()
        {
            if (_reader == null)
            {
                throw new NullReferenceException("The reader is not initialized");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Close();
            }
        }

        ~CsvReader()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
