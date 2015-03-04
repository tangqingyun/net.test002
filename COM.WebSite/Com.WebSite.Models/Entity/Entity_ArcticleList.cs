using Basement.Framework.Data.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Com.WebSite.Models.Entity
{
    public class Entity_ArcticleList:Entity_Arcticle
    {
        [Column("IndexPage", DbType.String, true, false)]
        public string IndexPage { set; get; }

        [Column("ListPage", DbType.String, true, false)]
        public string ListPage { set; get; }

        [Column("DetailPage", DbType.String, true, false)]
        public string DetailPage { set; get; }
    }
}
