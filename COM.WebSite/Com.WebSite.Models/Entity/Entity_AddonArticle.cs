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
    [Table("YN_AddonArticle")]
    public class Entity_AddonArticle : IEntity
    {

        /// 自增主键
        /// </summary>
        [Column("AddonID", DbType.Int64, true, true)]
        public long AddonID { set; get; }

        [Column("ArcticleID", DbType.Int64, true, false)]
        public long ArcticleID { set; get; }

        [Column("Body", DbType.String, true, false)]
        public string Body { set; get; }

    }

}
