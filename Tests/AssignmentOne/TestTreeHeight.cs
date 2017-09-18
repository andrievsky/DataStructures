using System.Collections.Generic;
using AssignmentOne;
using Tests.Helpers;
using Xunit;

namespace Tests.AssignmentOne
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
                var data = new DataSet("AssignmentOne/Resources/tree_height/tests");
                return data.Objects;
            }
        }
    }
}