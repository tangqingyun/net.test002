using Basement.Framework.Data;
using Com.WebSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.WebSite.DataAccess
{
    public class FlagDataProvider
    {
        IDatabase database = Database.DbConnection;
        public FlagDataProvider()
        {

        }

        public IEnumerable<Entity_Flag> GetFlagList()
        { 
            string exsql = "SELECT * FROM TB_Flags";
            return database.ExecuteList<Entity_Flag>(exsql);
        }
    }
}
