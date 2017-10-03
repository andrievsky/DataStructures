using System;
using System.Collections.Generic;

namespace Assignments.Week3
{
    public interface IBinaryHeapStrategy
    {
        bool SiftUpPredicate(int parent, int child);
        bool SiftDownPredicate(int parent, int child);
    }

    public class MinBinaryHeapStrategy : IBinaryHeapStrategy
    {
        public bool SiftUpPredicate(int parent, int child)
        {
            return parent > child;
        }

        public bool SiftDownPredicate(int index1, int index2)
        {
            return index1 < index2;
        }
    }
    
    public class BinaryHeap
    {
        private int _size;
        private int _maxSize = 16;
        private int[] _source;
        private readonly IBinaryHeapStrategy _strategy;
        private readonly IList<Tuple<int, int>> _swapsTracker;

        public BinaryHeap(IBinaryHeapStrategy strategy, IList<Tuple<int, int>> swapsTracker)
        {
            _source = new int[_maxSize];
            _strategy = strategy ?? throw new NullReferenceException();
            _swapsTracker = swapsTracker;
        }

        public void BuildFromArray(int[] source)
        {
            _source = source;
            _maxSize = _source.Length;
            _size = _maxSize - 1;

            for (var index = _maxSize / 2; index >= 0; index -= 1)
            {
                SiftDown(index);
            }
        }

        private static int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private static int LeftChild(int index)
        {
            return 2 * index + 1;
        }

        private static int RightChild(int index)
        {
            return 2 * index + 2;
        }

        private void Swap(int parentIndex, int childIndex)
        {
            var parentValue = _source[parentIndex];
            _source[parentIndex] = _source[childIndex];
            _source[childIndex] = parentValue;
            _swapsTracker?.Add(new Tuple<int, int>(parentIndex, childIndex));
        }

        private void SiftUp(int index)
        {
            while (index > 1 && _strategy.SiftUpPredicate(_source[Parent(index)], _source[index]))
            {
                Swap(Parent(index), index);
                index = Parent(index);
            }
        }

        private void SiftDown(int index)
        {
            while (true)
            {
                var maxIndex = index;
                var nextIndex = LeftChild(index);
                if (nextIndex <= _size && _strategy.SiftDownPredicate(_source[nextIndex], _source[maxIndex]))
                {
                    maxIndex = nextIndex;
                }
                nextIndex = RightChild(index);
                if (nextIndex <= _size && _strategy.SiftDownPredicate(_source[nextIndex], _source[maxIndex]))
                {
                    maxIndex = nextIndex;
                }
                if (index == maxIndex)
                {
                    return;
                }
                Swap(index, maxIndex);
                index = maxIndex;
            }
        }

        public void Insert(int value)
        {
            if (_size == _maxSize - 1)
            {
                throw new IndexOutOfRangeException();
            }
            _size += 1;
            _source[_size] = value;
            SiftUp(_size);
        }

        public int ExtractMax()
        {
            var maxValue = _source[0];
            _source[0] = _source[_size];
            _size -= 1;
            SiftDown(0);
            return maxValue;
        }

        public void Remove(int index)
        {
            _source[index] = int.MaxValue;
            SiftUp(index);
            ExtractMax();
        }

        public void ChangePriority(int index, int priority)
        {
            if (_strategy.SiftUpPredicate(_source[index], priority))
            {
                _source[index] = priority;
                SiftUp(index);
            }
            else
            {
                _source[index] = priority;
                SiftDown(index);
            }
        }
    }
}