using Calculator.Exceptions;
using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Helper
{
    internal class LoanCalculator
    {
        private const int PERIODS_IN_YEAR = 12;

        public Lending CalculateLoan(List<Lender> lenders, decimal targetAmount, int years)
        {
            AssertLenders(lenders);
            //we don't want to change the values in the original objects
            var lendersData = GetSortedLenders(lenders);
            var lendings = GetLendings(lendersData, targetAmount, years);
            if (lendings == null)
            {
                //couldn't fulfill the request
                return null;
            }
            //calculating blended (weighted) rate of loans
            var finalRate = lendings.Sum(lending => lending.Amount * lending.Rate) / lendings.Sum(lending => lending.Amount);
            var monthlyRepayment = lendings.Sum(lending => lending.MonthlyAmount);
            var totalRepayment = monthlyRepayment * 12 * years;
            return new Lending(targetAmount, finalRate, totalRepayment, monthlyRepayment);
        }

        private void AssertLenders(List<Lender> lenders)
        {
            if (lenders == null || lenders.Count == 0)
            {
                throw new CalculatorException("No lenders provided");
            }
        }

        private List<Lender> GetSortedLenders(IEnumerable<Lender> lenders)
        {
            var lendersData = lenders.Select(lender => lender.Clone() as Lender).ToList();
            lendersData.Sort(LendersSorter);
            return lendersData;
        }

        //Sorts by Rate (asc) and Amount (desc)
        private int LendersSorter(Lender a, Lender b)
        {
            if (a.Rate == b.Rate) return a.Available > b.Available ? -1 : 1;
            return a.Rate < b.Rate ? -1 : 1;
        }

        private List<Lending> GetLendings(List<Lender> lenders, decimal targetAmount, int years)
        {
            var lendings = new List<Lending>();
            var target = targetAmount;
            var math = new MathFunctions();
            while (target > 0 && lenders.Count > 0)
            {
                var firstLender = lenders[0];
                var amount = Math.Min(target, firstLender.Available);
                var monthlyInstallment = math.GetMonthlyInstallment(amount, firstLender.Rate, years);
                var totalAmount = math.GetTotalPayment(amount, firstLender.Rate, years);
                lendings.Add(new Lending(amount, firstLender.Rate, totalAmount, monthlyInstallment));
                firstLender.Available -= amount;
                target -= amount;
                if (firstLender.Available == 0)
                {
                    lenders.Remove(firstLender);
                }
            }

            return target > 0 ? null : lendings;
        }
    }
}
