using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace IQueryCombination
{
    public class QueryInterpreter
    {

        public WhereConditionInfo GetWhereCriterias(Query query, Func<string, string> propertyMap)
        {
             StringBuilder sqlBulider = new StringBuilder();
            List<DbParameter> ps = new List<DbParameter>();
            string queryOperator = FindSQLOperatorFor(query.QueryOperator);
            return null;
        }

        public string FindSQLOperatorFor(QueryOperator queryOperator)
        {
            switch (queryOperator)
            {
                case QueryOperator.And:
                    return " AND ";
                case QueryOperator.Or:
                    return " OR ";
                default:
                    throw new ArgumentException("No operator defined.");
            }
        }

        public string FindOrderBy(OrderByClause orderByClause, Func<string, string> propertyMap)
        {
            string orderC = orderByClause.Desc ? "DESC" : "ASC";
            if (null != propertyMap)
            {
                return string.Format("{0} {1}", propertyMap(orderByClause.PropertyName), orderC);
            }
            else
            {
                return string.Format("{0} {1}", orderByClause.PropertyName, orderC);
            }
        }

    }
}
