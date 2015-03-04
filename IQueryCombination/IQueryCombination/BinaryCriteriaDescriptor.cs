using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IQueryCombination
{
    public class BinaryCriteriaDescriptor : ICriteriaDescriptor
    {
        private const string Criterionformat = "{0} {1} {2}";
        protected Criterion _criteria;
        protected Func<string, string> _mapPropertyName;
        protected string _operator;
        public BinaryCriteriaDescriptor(Criterion criteria, string op, Func<string, string> mapPropertyName)
        {
            _criteria = criteria;
            _operator = op;
            _mapPropertyName = mapPropertyName;
        }

        public virtual string GetCriteriaStr()
        {
            return string.Format(Criterionformat, GetColmunName(), _operator, GetParameterName());
        }

        protected string GetColmunName()
        {
            string cName = _criteria.PropertyName;
            if (null != _mapPropertyName)
            {
                cName = _mapPropertyName(cName);
            }

            if (_criteria.HasPrefix())
            {
                cName = string.Format("{0}.{1}", _criteria.Prefix.Trim(), cName);
            }
            return cName;
        }

        protected virtual string GetParameterName()
        {
            if (null != _mapPropertyName)
            {
                return "@" + _mapPropertyName(_criteria.PropertyName);
            }

            return "@" + _criteria.PropertyName;
        }

        public virtual IEnumerable<DbParameter> GetParameters()
        {
            object vlaue = DBNull.Value;
            if (null != _criteria.Value)
            {
                vlaue = _criteria.Value;
            }
            return new SqlParameter[] { 
                new SqlParameter(GetParameterName(), vlaue)
            };
        }

    }
}
