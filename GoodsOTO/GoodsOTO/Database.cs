using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basement.Framework.Data;
using Basement.Framework.Data.Configuration;

namespace GoodsOTO
{
    public static class Database
    {
        /// <summary>
        /// 线上
        /// </summary>
        public static IDatabase OnLine_Goodsinfo
        {
            get
            {
                return new SqlServer(ConnectionConfig.Connections["OnLine_Goodsinfo"]);
            }
        }
        /// <summary>
        /// 线下
        /// </summary>
        public static IDatabase OffLine_Goodsinfo
        {
            get
            {
                return new SqlServer(ConnectionConfig.Connections["OffLine_Goodsinfo"]);
            }
        }

      
    }
}
