using System;
using System.Collections.Generic;
using System.IO;
using Assignments.Common;

namespace Assignments.Week3
{
    /// <summary>
    /// Task. The first step of the HeapSort algorithm is to create a heap from the array you want to sort. By the
    /*way, did you know that algorithms based on Heaps are widely used for external sort, when you need
    to sort huge files that don’t fit into memory of a computer?
    Your task is to implement this first step and convert a given array of integers into a heap. You will
    do that by applying a certain number of swaps to the array. Swap is an operation which exchanges
    elements 𝑎𝑖 and 𝑎𝑗 of the array 𝑎 for some 𝑖 and 𝑗. You will need to convert the array into a heap
    using only 𝑂(𝑛) swaps, as was described in the lectures. Note that you will need to use a min-heap
    instead of a max-heap in this problem.
    Input Format. The first line of the input contains single integer 𝑛. The next line contains 𝑛 space-separated
    integers 𝑎𝑖.
    Constraints. 1 ≤ 𝑛 ≤ 100 000; 0 ≤ 𝑖, 𝑗 ≤ 𝑛 − 1; 0 ≤ 𝑎0, 𝑎1, . . . , 𝑎𝑛−1 ≤ 109. All 𝑎𝑖 are distinct.
    Output Format. The first line of the output should contain single integer 𝑚 — the total number of swaps.
    𝑚 must satisfy conditions 0 ≤ 𝑚 ≤ 4𝑛. The next 𝑚 lines should contain the swap operations used
    to convert the array 𝑎 into a heap. Each swap is described by a pair of integers 𝑖, 𝑗 — the 0-based
    indices of the elements to be swapped. After applying all the swaps in the specified order the array
    must become a heap, that is, for each 𝑖 where 0 ≤ 𝑖 ≤ 𝑛 − 1 the following conditions must be true:
    1. If 2𝑖 + 1 ≤ 𝑛 − 1, then 𝑎𝑖 < 𝑎2𝑖+1.
    2. If 2𝑖 + 2 ≤ 𝑛 − 1, then 𝑎𝑖 < 𝑎2𝑖+2.
    Note that all the elements of the input array are distinct. Note that any sequence of swaps that has
    length at most 4𝑛 and after which your initial array becomes a correct heap will be graded as correct.*/
    /// </summary>
    public class BuildHeap
    {
    }
}

public class BuildHeap : IAssignment
{
    private int[] data;
    private IList<Tuple<int, int>> swaps;

    private Scanner input;
    private TextWriter output;


    public string Execute(String[] args)
    {
        new BuildHeap().solve();
        return output.ToString();
    }

    private void ReadData()
    {
        int n = input.NextInt();
        data = new int[n];
        for (int i = 0; i < n; ++i)
        {
            data[i] = input.NextInt();
        }
    }

    private string FormatOutput(IList<Tuple<int, int>> swaps)
    {
        var res = new StreamWriter();
        out.println(swaps.size());
        for (Swap swap :
        swaps) {
            out.println(swap.index1 + " " + swap.index2);
        }
    }

    private void generateSwaps()
    {
        swaps = new List<Swap>();
        // The following naive implementation just sorts 
        // the given sequence using selection sort algorithm
        // and saves the resulting sequence of swaps.
        // This turns the given array into a heap, 
        // but in the worst case gives a quadratic number of swaps.
        //
        // TODO: replace by a more efficient implementation
        for (int i = 0; i < data.length; ++i)
        {
            for (int j = i + 1; j < data.length; ++j)
            {
                if (data[i] > data[j])
                {
                    swaps.add(new Swap(i, j));
                    int tmp = data[i];
                    data[i] = data[j];
                    data[j] = tmp;
                }
            }
        }
    }

    public void solve()
    {
        in = new FastScanner();
            out = new PrintWriter(new BufferedOutputStream(System.out));
        readData();
        generateSwaps();
        writeResponse();
            out.close();
    }
}