using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IQueryCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = new Query<Person>();
            query.SqlEqual<Person>(m=>m.Name,"zhangsan")
                .SqlEqual<Person>(m=>m.ID,"1");

        }

    }


    public class Person
    {
        public int ID { set; get; }
        public string Name { set; get; }
    }


    public class Query {
        private IList<Criterion> _criteria;
        public Query()
            : this(new List<Criterion>())
        {
            
        }

        public Query(IList<Criterion> criteria)
        {
            _criteria = criteria;
        }

        public IEnumerable<Criterion> Criteria
        {
            get { return _criteria; }
        }

        public void Add(Criterion criterion)
        {
            if (criterion != null)
                _criteria.Add(criterion);
            else
            { 
                
            }
        }

        public QueryOperator QueryOperator { get; set; }

        public OrderByClause OrderByProperty { get; set; }

    }

    public enum QueryOperator
    {
        And,
        Or
    }

    /// <summary>
    /// 表示查询的排序属性
    /// </summary>
    public class OrderByClause
    {
        public string PropertyName { get; set; }
        public bool Desc { get; set; }
    }


    public class Query<T> : Query
    {
        IList<Query> SubQuerys { get; set; }
    }



}
