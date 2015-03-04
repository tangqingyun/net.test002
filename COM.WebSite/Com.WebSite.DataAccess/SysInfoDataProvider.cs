using Basement.Framework.Data;
using Com.WebSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Com.WebSite.DataAccess
{
    public class SysInfoDataProvider
    {
        IDatabase database = Database.DbConnection;
        public SysInfoDataProvider()
        {

        }

        public bool Save(IDictionary<string, string> dic)
        {
            StringBuilder script = new StringBuilder();
            foreach (var itm in dic)
            {
                script.AppendFormat("UPDATE TB_SysInfo SET Value='{0}' WHERE Name='{1}';", itm.Value, itm.Key);
            }
            return database.ExecuteNoQuery(script.ToString(), null);
        }

        public IEnumerable<Entity_SysInfo> SelectSysInfoList()
        {
            string sql = "SELECT * FROM TB_SysInfo";
            return database.ExecuteList<Entity_SysInfo>(sql);
        }
        /// <summary>
        /// 根据变量名获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Entity_SysInfo SelectSysInfoByName(string name)
        {
            string sql = "SELECT * FROM TB_SysInfo WHERE Name=@Name";
            IList<DbParameter> paramList = new List<DbParameter> { 
             new SqlParameter("Name",name)
            };
            return database.SingleAsModel<Entity_SysInfo>(sql, paramList);
        }

    }
}
