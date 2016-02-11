using Calculator.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Tests
{
    public class MathTests
    {
        [Fact]
        public void Test_Math_Instantiate()
        {
            var math = new MathFunctions();
            Assert.NotNull(math);
        }

        [Fact]
        public void Test_Math_Pow_0()
        {
            var math = new MathFunctions();
            Assert.Equal(1, math.Pow(10, 0));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        public void Test_Math_Pow(int value)
        {
            var math = new MathFunctions();
            Assert.Equal((decimal)Math.Pow(10, value), math.Pow(10, value));
        }


        [Fact]
        public void Test_Math_GetMonthlyInstallment()
        {
            var math = new MathFunctions();
            //12000 loan, annual rate 11%, for 4 years
            Assert.Equal(310.15m, Math.Round(math.GetMonthlyInstallment(12000m, 0.11m, 4), 2));
        }

        [Fact]
        public void Test_Math_GetTotalPayment()
        {
            var math = new MathFunctions();
            //12000 loan, annual rate 11%, for 4 years
            Assert.Equal(14887.02m, Math.Round(math.GetTotalPayment(12000m, 0.11m, 4), 2));
        }
    }
}
