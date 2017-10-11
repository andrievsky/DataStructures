using System.Linq;
using Assignments.Common;
using Xunit;

namespace Tests.Common
{
    public class TestDataSource
    {
        [Fact]
        public void CompareWithString()
        {
            var source = new DataSource().AppendLine("1 2 3 4").AppendLine("5 6 7 8");

            Assert.Equal(source.ToString(), $"1 2 3 4{DataSource.NewLine}5 6 7 8{DataSource.NewLine}");
        }

        [Fact]
        public void CompareWithSource()
        {
            var source = new DataSource().AppendLine("1 2 3 4").AppendLine("5 6 7 8");
            var failedSource = new DataSource().AppendLine("1 2 3 4").AppendLine("5 6 7 8 9");
            var successSource = new DataSource().AppendLine("1 2 3 4").AppendLine("5 6 7 8");

            Assert.True(source.Equals(successSource));
            Assert.False(source.Equals(failedSource));
        }
    }
}