using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uni2uni.script.main.common
{
    public class SysCommon
    {
        /// <summary>
        /// 库名
        /// </summary>
        public static string Database { set; get; }
        /// <summary>
        /// 表名
        /// </summary>
        public static string TableName { set; get; }
        /// <summary>
        /// 查询字段
        /// </summary>
        public static string[] Fields { set; get; }

        public static string StrSql { set; get; }

    }
}
