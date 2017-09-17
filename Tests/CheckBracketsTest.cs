using System.Collections.Generic;
using AssignmentOne;
using Tests.Helpers;
using Xunit;

namespace Tests
{
    public class CheckBracketsTest
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

        [Theory, MemberData("CheckBracketsDataSet")]
        public void TestDataSet(string[] input, string output)
        {
            Assert.Equal(output, CheckBrackets.Execute(input));
        }

        public static IEnumerable<object[]> CheckBracketsDataSet
        {
            get
            {
                var data = new DataSet("AssignmentOne/Resources/check_brackets_in_code/tests");
                return data.Objects;
            }
        }
    }
    

}