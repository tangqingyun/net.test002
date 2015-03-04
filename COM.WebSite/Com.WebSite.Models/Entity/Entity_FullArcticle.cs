using Basement.Framework.Data.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Com.WebSite.Models.Entity
{
    public class Entity_FullArcticle : Entity_Arcticle
    {

        [Column("ChannelName", DbType.String, true, false)]
        public string ChannelName { set; get; }

        [Column("Body", DbType.String, true, false)]
        public string Body { set; get; }

    }

}
