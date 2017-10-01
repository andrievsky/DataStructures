using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignments.Common
{
    public class DataSource : IDataSource
    {
        #region Constants
        public const string NewLine = "\r\n";
        #endregion
        
        #region State
        protected readonly IList<DataSourceLine> Lines = new List<DataSourceLine>();
        protected int Index = -1;
        #endregion

        #region Public

        /// <summary>
        /// Add new line
        /// </summary>
        /// <param name="lineSource"></param>
        public IDataSource Add(string lineSource)
        {
            Lines.Add(new DataSourceLine(lineSource));
            return this;
        }

        public override string ToString()
        {
            if (Lines.Count == 0)
            {
                return "";
            }
            var builder = new StringBuilder();

            /*for (var i = 0; i < Lines.Count - 1; i += 1)
            {
                builder.Append(Lines[i].Source);
                builder.Append(NewLine);
            }
            builder.Append(Lines.Last().Source);*/
            
            foreach (var line in Lines)
            {
                builder.Append(line.Source);
                builder.Append(NewLine);
            }
            
            return builder.ToString();
        }

        #endregion

        #region Iteration
        public DataSourceLine Current => Lines[Index];

        public virtual bool MoveNext()
        {
            if (Index == Lines.Count - 1)
            {
                return false;
            }
            Index += 1;
            return true;
        }

        public void Reset()
        {
            Index = -1;
        }

        public virtual void Dispose()
        {
            Reset();
        }
        #endregion

        #region Compare
        public bool Equals(IDataSource other)
        {
            return ToString() == other.ToString();
        }
        #endregion
    }
}