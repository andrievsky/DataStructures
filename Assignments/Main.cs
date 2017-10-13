using System;
using System.Diagnostics;
using Assignments.Exercises;

namespace Assignments
{
    /// <summary>
    /// The app entry point
    /// </summary>
    public class Assignments
    {
        private const int RepeatCount = 100;

        private static void Main(string[] args)
        {
            CheckPerforamance(() =>
            {
                var excersise = new StringPermutation();
                excersise.Permutation("abcdefghm", "");
            }, "Permutation");
        }

        private static void CheckPerforamance(Action action, string name)
        {
            action();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (var i = 0; i < RepeatCount; i++)
            {
                action();
            }
            stopWatch.Stop();
            Console.WriteLine($"Task {name} complete in {stopWatch.ElapsedMilliseconds / RepeatCount} milliseconds");
        }
    }
}