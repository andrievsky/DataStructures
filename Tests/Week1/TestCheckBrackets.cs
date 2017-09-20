using System.Collections.Generic;
using Assignments.Week1;
using Tests.Helpers;
using Xunit;

namespace Tests.Week1
{
    public class TestCheckBrackets
    {
        [Fact]
        public void TestStack()
        {
            var stack = new DsStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.Equal(3, stack.Top());
            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Top());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Top());
            Assert.Equal(1, stack.Pop());
        }

        [Theory, MemberData("GetDataSet")]
        public void TestDataSet(string[] input, string output)
        {
            var assignment = new CheckBrackets();
            Assert.Equal(output, assignment.Execute(input));
        }

        public static IEnumerable<object[]> GetDataSet
        {
            get
            {
                var data = new DataSet("Assignments/Week1/Resources/check_brackets_in_code/tests", limit: 1);
                return data.Objects;
            }
        }
    }
    

}