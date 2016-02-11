using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    internal interface IReader: IDisposable
    {
        bool Open(string parameter);
        void Close();
        string[] ReadData();
    }
}
