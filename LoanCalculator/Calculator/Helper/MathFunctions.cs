using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Helper
{
    internal class MathFunctions
    {
        public decimal Pow(decimal number, int d)
        {
            if (d == 0) return 1;
            var value = number;
            var positiveD = Math.Abs(d);
            for (int i = 2; i <= positiveD; ++i)
            {
                value *= number;
            }
            return d < 0 ? 1.0m / value : value;
        }
    }
}
