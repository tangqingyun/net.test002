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
    [Table("YN_Admin")]
    public class Entity_Admin : Entity_Base
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        [Column("ID", DbType.Guid, true, false)]
        public Guid ID { set; get; }
        [Column("TypeID", DbType.Int32, true, false)]
        public int TypeID { set; get; }
        [Column("Name", DbType.String, true, false)]
        public string Name { set; get; }
        [Column("Pwd", DbType.String, true, false)]
        public string Pwd { set; get; }
        [Column("Email", DbType.String, true, false)]
        public string Email { set; get; }
        [Column("LastLoginTime", DbType.DateTime, true, false)]
        public DateTime LastLoginTime { set; get; }
        [Column("LoginIP", DbType.String, true, false)]
        public string LoginIP { set; get; }
    }

    public class Entity_AdminExt : Entity_Admin
    {
        [Column("TypeName", DbType.String, true, false)]
        public string TypeName { set; get; }
    }
}
