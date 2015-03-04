using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Uni2uni.Framework.Data;

namespace EnterpriseMall.Models
{
    [Serializable]
    [Table("Users")]
    public class User:IEntity
    {
        [Column("UId", DbType.Guid, true, true)]
        public Guid UId { set; get; }

        [Column("Name", DbType.String, false, false)]
        public string Name { set; get; }

        [Column("Pwd", DbType.String, false, false)]
        public string Pwd { set; get; }

    }
}
