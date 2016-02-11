using Calculator.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Tests
{
    public class ProgramParametersTests
    {
        [Fact]
        public void Test_Parameters_Instantiate()
        {
            var parameterParser = new ParameterParser();
            Assert.NotNull(parameterParser);
        }

        [Fact]
        public void Test_Parameters_No_filename()
        {
            var parameterParser = new ParameterParser();
            var parameters = parameterParser.ParseParameters(new string[] { "1000" });
            Assert.Null(parameters);
        }

        [Fact]
        public void Test_Parameters_Wrong_Amount()
        {
            var parameterParser = new ParameterParser();
            var parameters = parameterParser.ParseParameters(new string[] { "data.csv", "abc" });
            Assert.Null(parameters);
        }

        [Fact]
        public void Test_Parameters_OK()
        {
            var parameterParser = new ParameterParser();
            var fileName = "data.csv";
            var amount = 1000m;
            var strAmount = amount.ToString();
            var parameters = parameterParser.ParseParameters(new string[] { fileName, strAmount });
            Assert.NotNull(parameters);
            Assert.Equal(fileName, parameters.FileName);
            Assert.Equal(amount, parameters.TargetAmount);
        }
    }
}
