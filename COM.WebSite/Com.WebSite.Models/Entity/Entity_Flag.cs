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
    [Table("TB_Flags")]
    public class Entity_Flag : IEntity
    {
        /// 自增主键
        /// </summary>
        [Column("ID", DbType.Int32, true, true)]
        public int ID { set; get; }

        [Column("Flag", DbType.String, true, false)]
        public string Flag { set; get; }

        [Column("Remark", DbType.String, true, false)]
        public string Remark { set; get; }

        [Column("Sort", DbType.Int32, true, true)]
        public int Sort { set; get; }

    }
}
