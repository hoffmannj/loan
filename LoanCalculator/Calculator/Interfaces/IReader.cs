using System;

namespace Calculator.Interfaces
{
    internal interface IReader: IDisposable
    {
        bool Open(string parameter);
        void Close();
        string[] ReadData();
    }
}
