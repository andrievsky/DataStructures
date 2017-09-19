using System.Collections.Generic;
using Assignments.Week1;
using Tests.Helpers;
using Xunit;

namespace Tests.Week1
{
    public class TestTreeHeight
    {
        [Theory, MemberData("GetDataSet")]
        public void TestDataSet(string[] input, string output)
        {
            var assignment = new TreeHeight();
            Assert.Equal(output, assignment.Execute(input));
        }

        public static IEnumerable<object[]> GetDataSet
        {
            get
            {
                var data = new DataSet("Assignments/Week1/Resources/tree_height/tests");
                return data.Objects;
            }
        }
    }
}