using Basement.Framework.Data;
using Basement.Framework.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.WebSite.DataAccess
{
    public static class Database
    {
        static Database() { }

        public static SqlServer DbConnection
        {
            get
            {
                return new SqlServer(ConnectionConfig.Connections["yingnuo_db"]);
            }
        }
         
    }
}
