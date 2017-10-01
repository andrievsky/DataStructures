using System;
using System.Collections.Generic;

namespace Assignments.Common
{
    public interface IDataSource : IEquatable<IDataSource>, IDisposable
    {
        IDataSource Add(string lineSource);
        DataSourceLine Current { get; }
        bool MoveNext();
        void Reset();
    }
}