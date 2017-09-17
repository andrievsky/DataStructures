using System;
using System.IO;
using Xunit;
using Tests.Helpers;
using AssignmentOne;
using Microsoft.DotNet.PlatformAbstractions;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var data = new DataSet(ResolvePath("AssignmentOne/Resources/check_brackets_in_code/tests"), limit: 5);
            foreach (var item in data.Items)
            {
                Assert.Equal(item.OutputData, check_brackets.Execute(item.IntpuData));
            }
        }
        
        string ResolvePath(string relativePath)
        {
            return Path.Combine(ApplicationEnvironment.ApplicationBasePath, "../../../../", relativePath);
        }
    }
    

}