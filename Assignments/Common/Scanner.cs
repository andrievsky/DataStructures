using System;

namespace Assignments.Common
{
    /// <summary>
    /// The very basic scanner implementation to simplify input data parsing from in cases where it has more advanced order. 
    /// 
    /// Designed to work with a list of strings insted of raw string to support the DataSet helper.
    /// </summary>
    public class Scanner
    {
        private readonly string[] _input;
        private int _index;

        public Scanner(string[] input)
        {
            _input = input;
            _index = 0;
        }

        public int NextInt()
        {
            if (!int.TryParse(_input[_index], out var value))
            {
                throw new ArgumentException(string.Format("{0} can not be parsed to int", _input[_index]));
            }
            Next();
            return value;
        }

        public void NextLine()
        {
            while (HasNext())
            {
                if (IsNextLine(_input[_index]))
                {
                    Next();
                    return;
                }
                Next();
            }
        }

        private void Next()
        {
            _index += 1;
        }

        private bool HasNext()
        {
            return _index != _input.Length;
        }

        private bool IsNextLine(string value)
        {
            return value == "";
        }
    }
}