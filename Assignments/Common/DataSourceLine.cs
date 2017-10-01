using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments.Common
{
    public class DataSourceLine
    {
        public string Source { get; }
        private IList<int> _numbers;
        private int _index = -1;

        public DataSourceLine(string source)
        {
            Source = source;
        }

        private void Process()
        {
            _numbers = new List<int>();
            var builder = new StringBuilder();
            foreach (var nextChar in Source)
            {
                if (nextChar == ' ')
                {
                    _numbers.Add(int.Parse(builder.ToString()));
                    builder.Clear();
                    continue;
                }
                builder.Append(nextChar);
            }
            if (builder.Length > 0)
            {
                _numbers.Add(int.Parse(builder.ToString()));
            }
        }

        public bool MoveNext()
        {
            if (_numbers == null)
            {
                Process();
            }
            if (_index == _numbers.Count - 1)
            {
                return false;
            }
            _index += 1;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public int Current => _numbers[_index];

        public int NextInt()
        {
            if (!MoveNext())
            {
                throw new IndexOutOfRangeException();
            }
            return Current;
        }

        public override string ToString()
        {
            return Source;
        }
    }
}