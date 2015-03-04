using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace IQueryCombination
{
    public interface ICriteriaDescriptor
    {
        string GetCriteriaStr();
        IEnumerable<DbParameter> GetParameters();
    }
}
