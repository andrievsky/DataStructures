using System;
using System.Collections.Generic;
using System.Linq;
using Assignments.Common;

namespace Assignments.Week1
{
    public class TreeHeight : IAssignment
    {
        public string Execute(string[] args)
        {
            var n = int.Parse(args[0]);
            var source = new int[n];
            for (var i = 0; i < n; i++)
            {
                source[i] = int.Parse(args[i + 2]);
            }
            return ComputeHeight(n, source).ToString();
        }

        private int ComputeHeightNaive(int n, int[] source)
        {
            // Replace this code with a faster implementation
            int maxHeight = 0;
            for (int vertex = 0; vertex < n; vertex++)
            {
                int height = 0;
                for (int i = vertex; i != -1; i = source[i])
                {
                    height++;
                }
                maxHeight = Math.Max(maxHeight, height);
            }
            return maxHeight;
        }

        private int ComputeHeight(int n, int[] source)
        {
            var tree = new Tree(n, source);
            return tree.GetMaxHeight();
        }
    }

    internal class Node
    {
        public readonly List<Node> Children = new List<Node>();

        /// <summary>
        /// Used for the loop solution
        /// </summary>
        public int Height = 0;

        /// <summary>
        /// Used for the solution with recursion
        /// </summary>
        /// <returns></returns>
        public int GetHeight()
        {
            var max = 0;
            foreach (var child in Children)
            {
                var height = child.GetHeight();
                if (height > max)
                {
                    max = height;
                }
            }
            return 1 + max;
        }
    }

    /// <summary>
    /// Take advantage of the fact that the labels for each tree node are integers in the range 0..𝑛−1:
    /// you can store each node in an array whose index is the label of the node. By storing the nodes in an array,
    /// you have 𝑂(1) access to any node given its label.
    /// 
    /// allocate 𝑛𝑜𝑑𝑒𝑠[𝑛]
    /// for 𝑖 ← 0 to 𝑛 − 1:
    /// 𝑛𝑜𝑑𝑒𝑠[𝑖] =new 𝑁𝑜𝑑𝑒
    /// 
    /// for 𝑐ℎ𝑖𝑙𝑑_𝑖𝑛𝑑𝑒𝑥 ← 0 to 𝑛 − 1:
    /// read 𝑝𝑎𝑟𝑒𝑛𝑡_𝑖𝑛𝑑𝑒𝑥
    /// if 𝑝𝑎𝑟𝑒𝑛𝑡_𝑖𝑛𝑑𝑒𝑥 == −1:
    /// 𝑟𝑜𝑜𝑡 ← 𝑐ℎ𝑖𝑙𝑑_𝑖𝑛𝑑𝑒𝑥
    /// else:
    /// 𝑛𝑜𝑑𝑒𝑠[𝑝𝑎𝑟𝑒𝑛𝑡_𝑖𝑛𝑑𝑒𝑥].𝑎𝑑𝑑𝐶ℎ𝑖𝑙𝑑(𝑛𝑜𝑑𝑒𝑠[𝑐ℎ𝑖𝑙𝑑_𝑖𝑛𝑑𝑒𝑥])
    /// </summary>
    internal class Tree
    {
        private Node _root;
        private Node[] _nodes;

        public Tree(int n, int[] source)
        {
            _nodes = new Node[n];
            for (int i = 0; i < n; i++)
            {
                _nodes[i] = new Node();
            }
            for (int i = 0; i < n; i++)
            {
                if (source[i] == -1)
                {
                    _root = _nodes[i];
                }
                else
                {
                    _nodes[source[i]].Children.Add(_nodes[i]);
                }
            }
        }

        /// <summary>
        /// Calculate the height with recursion
        /// </summary>
        /// <returns>Tree height</returns>
        public int GetMaxHeightWithRecursion()
        {
            return _root.GetHeight();
        }

        /// <summary>
        /// Expand the recursion to the loop
        /// </summary>
        /// <returns>Tree height</returns>
        public int GetMaxHeight()
        {
            _root.Height = 1;
            var queue = new LinkedList<Node>();
            queue.AddLast(_root);
            var maxHeight = 0;
            while (queue.Count > 0)
            {
                var parent = queue.First();
                if (parent.Height > maxHeight)
                {
                    maxHeight = parent.Height;
                }
                queue.RemoveFirst();
                foreach (var child in parent.Children)
                {
                    child.Height = parent.Height + 1;
                    queue.AddLast(child);
                }
            }
            return maxHeight;
        }
    }
}