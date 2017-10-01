using System;
using System.IO;

namespace Assignments.Common
{
    public class FileDataSource : DataSource
    {
        private readonly StreamReader _reader;
        private readonly FileStream _stream;
        private bool _complete;

        public FileDataSource(string filePath)
        {
            _stream = File.OpenRead(filePath);
            _reader = new StreamReader(_stream);
        }

        public override bool MoveNext()
        {
            if (_complete)
            {
                return base.MoveNext();
            }
            var line = _reader.ReadLine();
            if (line == null)
            {
                _stream.Dispose();
                _reader.Dispose();
                _complete = true;
                return false;
            }
            Lines.Add(new DataSourceLine(line));
            Index += 1;
            return true;
        }

        public override void Dispose()
        {
            base.Dispose();
            _stream.Dispose();
            _reader.Dispose();
        }
    }
}