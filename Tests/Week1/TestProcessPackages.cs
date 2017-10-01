using System.Collections.Generic;
using Assignments.Common;
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
            var input = new DataSource().Add("2 3").Add("0 1").Add("3 1").Add("10 1");
            var output = "0\r\n3\r\n10\r\n";
            var assignment = new ProcessPackages();
            Assert.Equal(output, assignment.Execute(input));
        }
        
        [Fact]
        public void Test17()
        {
            var input = new DataSource().Add("3 6").Add("0 2").Add("1 2").Add("2 2").Add("3 2").Add("4 2").Add("5 2");
            var output = "0\r\n2\r\n4\r\n6\r\n8\r\n-1\r\n";
            var assignment = new ProcessPackages();
            Assert.Equal(output, assignment.Execute(input));
        }

        [Theory, MemberData("GetDataSet")]
        public void TestDataSet(DataSource input, string output)
        {
            var assignment = new ProcessPackages();
            Assert.Equal(output, assignment.Execute(input));
        }

        public static IEnumerable<object[]> GetDataSet
        {
            get
            {
                var data = new DataSet("Assignments/Week1/Resources/network_packet_processing_simulation/tests");
                return data.Objects;
            }
        }
    }
}