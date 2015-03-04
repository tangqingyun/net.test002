using Basement.Framework.Data;
using Basement.Framework.Data.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Com.WebSite.Models.Entity
{
    public class Entity_Base : IEntity
    {
        public Entity_Base() {
            this.CreateBy = new Guid("83454480-7CB0-451B-8128-CAC48B0552B4");
            this.UpdateBy = new Guid("83454480-7CB0-451B-8128-CAC48B0552B4");
            this.CreateTime = DateTime.Now;
            this.UpdateTime = DateTime.Now;
        }
        [Column("CreateBy", DbType.Guid, true, false)]
        public Guid CreateBy { set; get; }
        [Column("UpdateBy", DbType.Guid, true, false)]
        public Guid UpdateBy { set; get; }
        [Column("CreateTime", DbType.DateTime, true, false)]
        public DateTime CreateTime { set; get; }
        [Column("UpdateTime", DbType.DateTime, true, false)]
        public DateTime UpdateTime { set; get; }
    }
}
