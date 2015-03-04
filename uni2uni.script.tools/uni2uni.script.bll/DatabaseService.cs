using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uni2uni.script.dal;
using uni2uni.script.model;

namespace uni2uni.script.bll
{
    public class DatabaseService
    {
        private DatabaseProvider dataProvider;
        public DatabaseService() {
            dataProvider = new DatabaseProvider();
        }

          /// <summary>
        /// 获得所有数据库
        /// </summary>
        /// <returns></returns>
        public IList<DataBase> GetDatabase()
        {
            return dataProvider.GetDatabase();
        }

       


        /// <summary>
        /// 获得库中所有数据表;
        /// </summary>
        /// <returns></returns>
        public IList<Table> GetAllTables(string dbName)
        {
            return dataProvider.GetAllTables(dbName);
        }
    }
}
