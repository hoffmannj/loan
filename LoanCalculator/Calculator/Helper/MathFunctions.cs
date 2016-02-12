using System;

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

        public decimal GetMonthlyInstallment(decimal amount, decimal rate, int years)
        {
            var monthlyRate = rate / 12;
            var periods = years * 12;
            return (amount * monthlyRate) / (1.0m - Pow(1.0m + monthlyRate, -periods));
        }

        public decimal GetTotalPayment(decimal amount, decimal rate, int years)
        {
            return GetMonthlyInstallment(amount, rate, years) * 12 * years;
        }
    }
}
