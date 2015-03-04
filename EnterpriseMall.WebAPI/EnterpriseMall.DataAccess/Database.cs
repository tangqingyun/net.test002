using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni2uni.Framework.Data;
using Uni2uni.Framework.Data.Configuration;


namespace EnterpriseMall.DataAccess
{
    public static class Database
    {
        public static IDatabase User
        {
            get
            {
                return new SqlServer(ConnectionConfig.Connections["User"]);
            }
        }

        public static IDatabase Order
        {
            get
            {
                return new SqlServer(ConnectionConfig.Connections["Order"]);
            }
        }

        public static IDatabase EMall
        {
            get
            {
                return new SqlServer(ConnectionConfig.Connections["EMall"]);
            }
        }
    }
}
