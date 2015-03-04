using Basement.Framework.Data;
using Basement.Framework.Data.Attribute;
using Com.WebSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Com.WebSite.Models
{
    [Serializable]
    [Table("YN_Channel")]
    public class Entity_Channel : Entity_Base
    {
        /// <summary>
        /// 栏目ID
        /// </summary>
        [Column("ChannelID", DbType.Int32, true, true)]
        public int ChannelID { set; get; }
        /// <summary>
        /// 上级栏目ID
        /// </summary>
        [Column("Reid", DbType.Int32, true, false)]
        public int Reid { set; get; }
        /// <summary>
        /// 排序
        /// </summary>
        [Column("SortRank", DbType.Int32, true, false)]
        public int SortRank { set; get; }
        /// <summary>
        /// 栏目名称
        /// </summary>
        [Column("ChannelName", DbType.String, true, false)]
        public string ChannelName { set; get; }
        /// <summary>
        /// 内容模型ID
        /// </summary>
        [Column("ModuleID", DbType.Int32, true, false)]
        public int ModuleID { set; get; }
        /// <summary>
        /// 是否开启
        /// </summary>
        [Column("IsHidden", DbType.Boolean, true, false)]
        public bool IsHidden { set; get; }
        /// <summary>
        /// 文件保存目录
        /// </summary>
        [Column("FileDir", DbType.String, true, false)]
        public string FileDir { set; get; }
        /// <summary>
        /// SEOTitle
        /// </summary>
        [Column("SEOTitle", DbType.String, true, false)]
        public String SEOTitle { set; get; }
        /// <summary>
        /// 关键字
        /// </summary>
        [Column("Keywords", DbType.String, true, false)]
        public String Keywords { set; get; }
        /// <summary>
        /// 描述
        /// </summary>
        [Column("Description", DbType.String, true, false)]
        public string Description { set; get; }
        /// <summary>
        /// 内容
        /// </summary>
        [Column("Content", DbType.String, true, false)]
        public string Content { set; get; }
        /// <summary>
        /// 封面页
        /// </summary>
        [Column("IndexPage", DbType.String, true, false)]
        public string IndexPage { set; get; }
        /// <summary>
        /// 列表页
        /// </summary>
        [Column("ListPage", DbType.String, true, false)]
        public string ListPage { set; get; }
        /// <summary>
        /// 详细页
        /// </summary>
        [Column("DetailPage", DbType.String, true, false)]
        public string DetailPage { set; get; } 
    }
}
