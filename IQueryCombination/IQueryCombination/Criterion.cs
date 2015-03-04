using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IQueryCombination
{
    public class Criterion
    {

        private string _prefix;
        private string _propertyName;//实体属性
        private object _value;//进行比较的值
        private CriteriaOperator _criteriaOperator;//何种比较方式
        public Criterion(string propertyName, object value, CriteriaOperator criteriaOperator, string prefix = "")
        {
            _propertyName = propertyName;
            _value = value;
            _criteriaOperator = criteriaOperator;
            _prefix = prefix;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public object Value
        {
            get { return _value; }
        }

        public string Prefix
        {
            get { return _prefix; }
        }

        public CriteriaOperator criteriaOperator
        {
            get { return _criteriaOperator; }
        }

        public bool HasPrefix()
        {
            return !string.IsNullOrWhiteSpace(Prefix);
        }

        public static Criterion Create<T>(Expression<Func<T, object>> expression, Object value, CriteriaOperator criteriaOperator, string prefix = "")
        {
            string propertyName = ResolvePropertyName<T>(expression);
            Criterion myCriterion = new Criterion(propertyName, value, criteriaOperator);
            return myCriterion;
        }

        private static string ResolvePropertyName<T>(Expression<Func<T, object>> expression)
        {
            var expr = expression.Body as MemberExpression;
            if (expr == null)
            {
                var u = expression.Body as UnaryExpression;
                expr = u.Operand as MemberExpression;
            }
            return expr.ToString().Substring(expr.ToString().IndexOf(".") + 1);
        }

    }


    public enum CriteriaOperator
    {
        Equal,//=
        NotApplicable,//≠
        LessThan,//<
        LessThanOrEqual,// <=
        GreaterThan, //>
        GreaterThanEqual,//>=
        Like,//like
        BetweenAnd, //betwween and
        In//in
    }

}
