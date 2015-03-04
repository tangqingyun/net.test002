using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IQueryCombination
{
    public static class QueryExt
    {
        public static Query<T> SqlEqual<T>(this Query<T> query, Expression<Func<T, object>> property, Object value)
        {
            var  criterion=Criterion.Create<T>(property, value, CriteriaOperator.Equal, "");
            query.Add(criterion);
            return query;
        }



        

    }
}
