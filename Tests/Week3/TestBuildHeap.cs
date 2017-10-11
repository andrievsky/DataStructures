using System.Collections.Generic;
using Assignments.Common;
using Assignments.Week3;
using Tests.Helpers;
using Xunit;

namespace Tests.Week3
{
    public class TestBuildHeap
    {
        [Fact]
        public void TestSample1()
        {
            var input = new DataSource();
            input.AppendLine("5");
            input.AppendLine("5 4 3 2 1");
            var output = new DataSource();
            output.AppendLine("3");
            output.AppendLine("1 4");
            output.AppendLine("0 1");
            output.AppendLine("1 3");
            var assingment = new BuildHeap();

            Assert.Equal(output.ToString("\n"), assingment.Execute(input));
        }

        [Theory, MemberData("GetDataSet")]
        public void TestDataSet(DataSource input, string output)
        {
            var assignment = new BuildHeap();
            Assert.Equal(output, assignment.Execute(input));
        }

        public static IEnumerable<object[]> GetDataSet
        {
            get
            {
                var data = new DataSet("Assignments/Week3/Resources/make_heap/tests");
                return data.Objects;
            }
        }
    }
}