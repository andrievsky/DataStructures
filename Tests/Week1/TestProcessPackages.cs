using System.Collections.Generic;
using Assignments.Week1;
using Tests.Helpers;
using Xunit;

namespace Tests.Week1
{
    public class TestProcessPackages
    {
        [Fact]
        public void Test18()
        {
            var input = new string[] {"2", "3", "", "0", "1", "", "3", "1", "", "10", "1"};
            var output = "0\r\n3\r\n10";
            var assignment = new ProcessPackages();
            Assert.Equal(output, assignment.Execute(input));
        }

        [Theory, MemberData("GetDataSet")]
        public void TestDataSet(string[] input, string output)
        {
            var assignment = new ProcessPackages();
            Assert.Equal(output, assignment.Execute(input));
        }

        public static IEnumerable<object[]> GetDataSet
        {
            get
            {
                var data = new DataSet("Assignments/Week1/Resources/network_packet_processing_simulation/tests",
                    limit: 1);
                return data.Objects;
            }
        }
    }
}