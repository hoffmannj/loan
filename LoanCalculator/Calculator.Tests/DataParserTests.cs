using Calculator.Exceptions;
using Calculator.Helper;
using Xunit;

namespace Calculator.Tests
{
    public class DataParserTests
    {
        [Fact]
        public void Test_DataParser_Instantiate()
        {
            var parser = new DataParser();
            Assert.NotNull(parser);
        }

        [Fact]
        public void Test_DataParser_Wrong_Number_Of_Fields()
        {
            var data = new string[] { "123.123", "1000" };
            var parser = new DataParser();
            Assert.Throws<DataParsingException>(() =>
            {
                var result = parser.Parse(data);
            });
        }

        [Fact]
        public void Test_DataParser_Missing_Name()
        {
            var data = new string[] { "", "123.123", "1000" };
            var parser = new DataParser();
            Assert.Throws<DataParsingException>(() =>
            {
                var result = parser.Parse(data);
            });
        }

        [Fact]
        public void Test_DataParser_Wrong_Rate()
        {
            var data = new string[] { "Joe", "123#123", "1000" };
            var parser = new DataParser();
            Assert.Throws<DataParsingException>(() =>
            {
                var result = parser.Parse(data);
            });
        }
        
        [Fact]
        public void Test_DataParser_Wrong_Amount()
        {
            var data = new string[] { "Joe", "123.123", "10%0" };
            var parser = new DataParser();
            Assert.Throws<DataParsingException>(() =>
            {
                var result = parser.Parse(data);
            });
        }

        [Fact]
        public void Test_DataParser_OK()
        {
            var data = new string[] { "Joe", "123.123", "1000" };
            var parser = new DataParser();
            var result = parser.Parse(data);
            Assert.NotNull(result);
            Assert.Equal("Joe", result.Name);
            Assert.Equal(123.123m, result.Rate);
            Assert.Equal(1000m, result.Available);
        }
    }
}
