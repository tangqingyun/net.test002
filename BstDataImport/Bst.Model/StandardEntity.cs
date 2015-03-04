using Basement.Framework.Data.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bst.Model
{
    public class StandardEntity : BaseEntity
    {
        public StandardEntity()
        {
            this.CreateTime = DateTime.Now;
            this.CreateBy = new Guid();
            this.UpdateBy = new Guid();
            this.UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreateTime", DbType.DateTime, false, false)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户Id
        /// </summary>
        [Column("CreateBy", DbType.Guid, false, false)]
        public Guid CreateBy { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Column("UpdateTime", DbType.DateTime, false, false)]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 最后更新用户Id
        /// </summary>
        [Column("UpdateBy", DbType.Guid, false, false)]
        public Guid UpdateBy { get; set; }
    }
}
