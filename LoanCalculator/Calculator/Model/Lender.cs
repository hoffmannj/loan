using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    internal class Lender : ICloneable
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public decimal Available { get; set; }

        public Lender(string name, decimal rate, decimal available)
        {
            Name = name;
            Rate = rate;
            Available = available;
        }

        public object Clone()
        {
            return new Lender(Name, Rate, Available);
        }
    }
}
