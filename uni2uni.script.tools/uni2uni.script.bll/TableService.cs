using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uni2uni.script.dal;
using uni2uni.script.model;

namespace uni2uni.script.bll
{
    public class TableService
    {
        private TableProvider dataProvider;
        public TableService(string dbname)
        {
            dataProvider = new TableProvider(dbname);
        }

        /// <summary>
        /// 获取查询数据
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public DataTable GetQueryData(string strSql)
        {
            return dataProvider.GetQueryData(strSql);
        }

        /// <summary>
        /// 获得表中字段属性
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public IList<Column> GetTableColumnPropyte(string table)
        {
            return dataProvider.GetTableColumnPropyte(table);
        }

    }
}
