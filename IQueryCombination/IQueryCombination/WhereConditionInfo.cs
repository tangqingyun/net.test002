using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace IQueryCombination
{
    public class WhereConditionInfo
    {
        private string _whereCondition;

        private string _orderbyClauses;

        private IList<DbParameter> _parameters;

        public WhereConditionInfo(string whereCondition, string oderbyClauses, IList<DbParameter> parameters)
        {
            _whereCondition = whereCondition;
            _parameters = parameters;
            _orderbyClauses = oderbyClauses;
        }

        public string WhereCondition
        {
            get
            {
                return _whereCondition;
            }
        }

        public IList<DbParameter> Parameters
        {
            get
            {
                return _parameters;
            }
        }

        public string Orderby
        {
            get
            {
                return _orderbyClauses;
            }
        }

    }
}
