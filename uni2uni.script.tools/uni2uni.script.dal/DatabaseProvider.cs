using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uni2uni.script.model;

namespace uni2uni.script.dal
{
    public class DatabaseProvider
    {
        private MSSQL.DatabaseHelper db;
        public DatabaseProvider()
        {
            db = new MSSQL.DatabaseHelper("master");
        }

        /// <summary>
        /// 获得所有数据库
        /// </summary>
        /// <returns></returns>
        public IList<DataBase> GetDatabase()
        {
            string sql = "SELECT ROW_NUMBER() OVER(ORDER BY Name) AS Sequence ,Name from Master..SysDatabases ORDER BY Name";
            return db.GetListData<DataBase>(sql, CommandType.Text, null);
        }

        

        /// <summary>
        /// 获得库中所有数据表;
        /// </summary>
        /// <returns></returns>
        public IList<Table> GetAllTables(string dbName)
        {
            string sql = "use " + dbName + ";select name as TableName,ROW_NUMBER() OVER(ORDER BY name) AS Sequence from sys.tables";
            return db.GetListData<Table>(sql, CommandType.Text, null);
        }
 
    }
}
