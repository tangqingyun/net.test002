using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uni2uni.script.model;

namespace uni2uni.script.dal
{
    public class TableProvider
    {
        private MSSQL.DatabaseHelper db;
        public TableProvider(string dbname)
        {
            try
            {
                db = new MSSQL.DatabaseHelper(dbname);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        /// <summary>
        /// 获取查询数据
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public DataTable GetQueryData(string strSql)
        {
           return db.GetDataTable(strSql,CommandType.Text,null);
        }

        /// <summary>
        /// 获得表中字段属性
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public IList<Column> GetTableColumnPropyte(string tableName)
        {
            string sql = string.Format(@"SELECT
        Sequence=a.colorder,
        Name=a.name,
        Tag=case   when   COLUMNPROPERTY(   a.id,a.name,'IsIdentity')=1   then   'yes' else   'no'   end,
        [Key]=case   when   exists(SELECT   1   FROM   sysobjects   where   xtype='PK'   and   name   in   (
        SELECT   name   FROM   sysindexes   WHERE   indid   in(
        SELECT   indid   FROM   sysindexkeys   WHERE   id   =   a.id   AND   colid=a.colid
        )))   then   'yes'   else   'no'   end,
        Type=b.name,
        Byte=a.length,
        Length=COLUMNPROPERTY(a.id,a.name,'PRECISION'),
        DecimalDigits=isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0),
        NullTag=case   when   a.isnullable=1   then   'yes' else   'no'   end,
        DefaultValue=isnull(e.text,''),
        ColumnDesc=isnull(g.[value],'')
        FROM   syscolumns   a
        left   join   systypes   b   on   a.xusertype=b.xusertype
        inner   join   sysobjects   d   on   a.id=d.id     and   d.xtype='U'   and     d.name<>'dtproperties'
        left   join   syscomments   e   on   a.cdefault=e.id
        left   join   sys.extended_properties   g   on   a.id=g.major_id   and   a.colid=g.minor_id
        left   join   sys.extended_properties   f   on   d.id=f.major_id   and   f.minor_id=0
        where   d.name='{0}' 
        order   by   a.id,a.colorder", tableName);
            return db.GetListData<Column>(sql, CommandType.Text, null);
        }


    }
}
