using System;
using System.Collections.Generic;
using Assignments.Common;

namespace Assignments.Week3
{
    /// <summary>
    // Task. The first step of the HeapSort algorithm is to create a heap from the array you want to sort. By the
    // way, did you know that algorithms based on Heaps are widely used for external sort, when you need
    // to sort huge files that don’t fit into memory of a computer?
    // Your task is to implement this first step and convert a given array of integers into a heap. You will
    // do that by applying a certain number of swaps to the array. Swap is an operation which exchanges
    // elements 𝑎𝑖 and 𝑎𝑗 of the array 𝑎 for some 𝑖 and 𝑗. You will need to convert the array into a heap
    // using only 𝑂(𝑛) swaps, as was described in the lectures. Note that you will need to use a min-heap
    // instead of a max-heap in this problem.
    // Input Format. The first line of the input contains single integer 𝑛. The next line contains 𝑛 space-separated
    // integers 𝑎𝑖.
    // Constraints. 1 ≤ 𝑛 ≤ 100 000; 0 ≤ 𝑖, 𝑗 ≤ 𝑛 − 1; 0 ≤ 𝑎0, 𝑎1, . . . , 𝑎𝑛−1 ≤ 109. All 𝑎𝑖 are distinct.
    // Output Format. The first line of the output should contain single integer 𝑚 — the total number of swaps.
    // 𝑚 must satisfy conditions 0 ≤ 𝑚 ≤ 4𝑛. The next 𝑚 lines should contain the swap operations used
    // to convert the array 𝑎 into a heap. Each swap is described by a pair of integers 𝑖, 𝑗 — the 0-based
    // indices of the elements to be swapped. After applying all the swaps in the specified order the array
    // must become a heap, that is, for each 𝑖 where 0 ≤ 𝑖 ≤ 𝑛 − 1 the following conditions must be true:
    // 1. If 2𝑖 + 1 ≤ 𝑛 − 1, then 𝑎𝑖 < 𝑎2𝑖+1.
    // 2. If 2𝑖 + 2 ≤ 𝑛 − 1, then 𝑎𝑖 < 𝑎2𝑖+2.
    // Note that all the elements of the input array are distinct. Note that any sequence of swaps that has
    // length at most 4𝑛 and after which your initial array becomes a correct heap will be graded as correct.
    /// </summary>
    public class BuildHeap : IAssignment
    {
        public string Execute(IDataSource input)
        {
            var swaps = GenerateSwaps(input);
            var res = new DataSource();
            res.Add(swaps.Count.ToString());
            foreach (var swap in swaps)
            {
                res.Add(swap.Item1 + " " + swap.Item2);
            }
            return res.ToString("\n");
        }

        private IList<Tuple<int, int>> GenerateSwaps(IDataSource input)
        {
            var swaps = new List<Tuple<int, int>>();
            // Init
            input.MoveNext();
            var n = input.Current.NextInt();
            var data = new int[n];
            input.MoveNext();
            for (var i = 0; i < n; i += 1)
            {
                data[i] = input.Current.NextInt();
            }
            
            // The following naive implementation just sorts 
            // the given sequence using selection sort algorithm
            // and saves the resulting sequence of swaps.
            // This turns the given array into a heap, 
            // but in the worst case gives a quadratic number of swaps.
            /*for (int i = 0; i < data.Length; ++i)
            {
                for (int j = i + 1; j < data.Length; ++j)
                {
                    if (data[i] > data[j])
                    {
                        swaps.Add(Tuple.Create(i, j));
                        int tmp = data[i];
                        data[i] = data[j];
                        data[j] = tmp;
                    }
                }
            }*/

            var heap = new BinaryHeap(new MinBinaryHeapStrategy(), swaps);
            heap.BuildFromArray(data);
            
            return swaps;
        }
    }
}