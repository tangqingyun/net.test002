using Basement.Framework.Data;
using Basement.Framework.Data.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Com.WebSite.Models.Entity
{

    /// <summary>
    /// 系统设置
    /// </summary>
    [Serializable]
    [Table("TB_SysInfo")]
    public class Entity_SysInfo : IEntity
    {
        [Column("ID", DbType.Guid, true, false)]
        public Guid ID { set; get; }
        [Column("Name", DbType.String, true, false)]
        public string Name { set; get; }
        [Column("Value", DbType.String, true, false)]
        public string Value { set; get; }
        [Column("Type", DbType.Int32, true, false)]
        public int Type { set; get; }
    }
}
