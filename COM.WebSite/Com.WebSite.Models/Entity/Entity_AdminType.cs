using Basement.Framework.Data;
using Basement.Framework.Data.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Com.WebSite.Models.Entity
{
    [Serializable]
    [Table("YN_AdminType")]
    public class Entity_AdminType : Entity_Base
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        [Column("ID", DbType.Int32, true, true)]
        public int ID { set; get; }
        /// <summary>
        /// 级别
        /// </summary>
        [Column("Rank", DbType.Int32, true, false)]
        public int Rank { set; get; }
        /// <summary>
        /// 类型名
        /// </summary>
        [Column("TypeName", DbType.String, true, false)]
        public string TypeName { set; get; }
        /// <summary>
        /// 权限
        /// </summary>
        [Column("Purviews", DbType.String, true, false)]
        public string Purviews { set; get; }

    }

    public class Entity_Role : Entity_AdminType
    {
        [Column("Name", DbType.String, true, false)]
        public string Name { set; get; }
    }

}
