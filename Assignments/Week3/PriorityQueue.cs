using System;

namespace Assignments.Week3
{
    public interface IPrioritizable
    {
        void SetMaxPriority();
    }

    public class PriorityQueue<T> where T : IComparable<T>, IPrioritizable
    {
        private int _size;
        private int _maxSize = 16;
        private T[] _source;

        public PriorityQueue(int maxSize = 16)
        {
            _source = new T[_maxSize];
        }

        public void BuildFromArray(T[] source)
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
            return index / 2;
        }

        private static int LeftChild(int index)
        {
            return 2 * index;
        }

        private static int RightChild(int index)
        {
            return 2 * index + 1;
        }

        private void Swap(int parentIndex, int childIndex)
        {
            var parentValue = _source[parentIndex];
            _source[parentIndex] = _source[childIndex];
            _source[childIndex] = parentValue;
        }

        private void SiftUp(int index)
        {
            while (index > 1 && _source[index].CompareTo(_source[Parent(index)]) > 0)
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
                if (nextIndex <= _size && _source[maxIndex].CompareTo(_source[nextIndex]) < 0)
                {
                    maxIndex = nextIndex;
                }
                nextIndex = RightChild(index);
                if (nextIndex <= _size && _source[maxIndex].CompareTo(_source[nextIndex]) < 0)
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

        public void Insert(T value)
        {
            if (_size == _maxSize)
            {
                throw new IndexOutOfRangeException();
            }
            _size += 1;
            _source[_size] = value;
            SiftUp(_size);
        }

        public T ExtractMax()
        {
            var maxValue = _source[1];
            _source[0] = _source[_size];
            _size -= 1;
            SiftDown(1);
            return maxValue;
        }

        public T GetMax()
        {
            return _source[1];
        }

        public void Remove(int index)
        {
            _source[index].SetMaxPriority();
            SiftUp(index);
            ExtractMax();
        }

        public void UpdateMax()
        {
            SiftDown(1);
        }
    }
}