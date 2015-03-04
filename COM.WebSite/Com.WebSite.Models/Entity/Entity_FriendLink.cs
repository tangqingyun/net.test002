using Basement.Framework.Data.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Com.WebSite.Models.Entity
{
    [Serializable]
    [Table("TB_FriendLink")]
    public class Entity_FriendLink : Entity_Base
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        [Column("ID", DbType.Int32, true, true)]
        public int ID { set; get; }
        [Column("Url", DbType.String, true, false)]
        public string Url { set; get; }
        [Column("WebName", DbType.String, true, false)]
        public string WebName { set; get; }
        [Column("SortRank", DbType.Int32, true, false)]
        public int SortRank { set; get; }
        [Column("Logo", DbType.String, true, false)]
        public string Logo { set; get; }
        [Column("TypeID", DbType.Int32, true, false)]
        public int TypeID { set; get; }
        [Column("Email", DbType.String, true, false)]
        public string Email { set; get; }
        [Column("Description", DbType.String, true, false)]
        public string Description { set; get; }
        [Column("Ischeck", DbType.Int32, true, false)]
        public int Ischeck { set; get; }
    }
}
