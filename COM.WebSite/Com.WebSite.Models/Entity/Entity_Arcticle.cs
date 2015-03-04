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
    [Table("YN_Arcticle")]
    public class Entity_Arcticle : Entity_Base
    {
        [Column("ArcticleID", DbType.Int64, true, true)]
        public long ArcticleID { set; get; }
        [Column("ChannelID", DbType.Int32, true, false)]
        public int ChannelID { set; get; }
        [Column("Title", DbType.String, true, false)]
        public string Title { set; get; }
        [Column("Writer", DbType.String, true, false)]
        public string Writer { set; get; }
        [Column("Tags", DbType.String, true, false)]
        public string Tags { set; get; }
        [Column("Source", DbType.String, true, false)]
        public string Source { set; get; }
        [Column("Flag", DbType.String, true, false)]
        public string Flag { set; get; }
        [Column("LitPic", DbType.String, true, false)]
        public string LitPic { set; get; }
        [Column("ThumPic", DbType.String, true, false)]
        public string ThumPic { set; get; }
        [Column("Keywords", DbType.String, true, false)]
        public string Keywords { set; get; }
        [Column("Description", DbType.String, true, false)]
        public string Description { set; get; }
        [Column("Click", DbType.Int32, true, false)]
        public int Click { set; get; }
        [Column("StaticPath", DbType.String, true, false)]
        public string StaticPath { set; get; }
        [Column("IsHtml", DbType.Int32, true, false)]
        public int IsHtml { set; get; }
        [Column("FileName", DbType.String, true, false)]
        public string FileName { set; get; }
        [Column("RedireUrl", DbType.String, true, false)]
        public string RedireUrl { set; get; }
    }
}
