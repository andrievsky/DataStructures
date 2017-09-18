using System;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentOne
{
    public class TreeHeight
    {

        public string Execute(string[] args)
        {
            var n = int.Parse(args[0]);
            var source = new int[n];
            for (var i = 0; i < n; i++)
            {
                source[i] = int.Parse(args[i+2]);
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
        public List<Node> Children = new List<Node>();
        public int Height = 0;

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

        public int GetMaxHeightWithRecursion()
        {
            return _root.GetHeight();
        }
        
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