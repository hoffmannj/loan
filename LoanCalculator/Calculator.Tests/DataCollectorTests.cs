using Calculator.Helper;
using Calculator.Tests.Reader;
using System;
using Xunit;

namespace Calculator.Tests
{
    public class DataCollectorTests
    {
        [Fact]
        public void Test_DataCollector_Reader_NULL()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var dc = new DataCollector(null);
            });
        }

        [Fact]
        public void Test_DataCollector_FakeReader()
        {
            var dc = new DataCollector(new FakeReader());
            var result = dc.Collect(string.Empty);
            Assert.NotNull(result);
            Assert.Equal(7, result.Count);
        }
    }
}
