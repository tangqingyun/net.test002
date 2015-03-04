using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uni2uni.script.bll;
using uni2uni.script.main.common;
using uni2uni.script.model;

namespace uni2uni.script.main.template
{
    public partial class sqltemplate
    {
        public readonly DatabaseService dbService = new DatabaseService();
        public static string Database = SysCommon.Database;
        public static string TableName = SysCommon.TableName;
        public static string[] Fields = SysCommon.Fields;
        public static string SQL = SysCommon.StrSql;
    }
}
