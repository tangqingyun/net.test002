using Basement.Framework.Data.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bst.Model
{
    [Serializable]
    [Table("SP_ShopImg")]
    public class ShopImgEntity : StandardEntity
    {
        /// <summary>
        /// 商户图片ID
        /// </summary>
        [Column("ShopImgId", DbType.Guid, true, false)]
        public Guid ShopImgId { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        [Column("ShopId", DbType.Guid, false, false)]
        public Guid ShopId { get; set; }

        /// <summary>
        /// 分类，Environment：环境 、Service：服务
        /// </summary>
        [Column("Category", DbType.String, false, false)]
        public string Category { get; set; }

        /// <summary>
        /// 图片路径（不含域名的相对路径）
        /// </summary>
        [Column("ImgPath", DbType.String, false, false)]
        public string ImgPath { get; set; }

        /// <summary>
        /// 图片标题
        /// </summary>
        [Column("ImgTitle", DbType.String, false, false)]
        public string ImgTitle { get; set; }

        /// <summary>
        /// 缩略图路径（不含域名的相对路径）
        /// </summary>
        [Column("ThumbnailPath", DbType.String, false, false)]
        public string ThumbnailPath { get; set; }

        /// <summary>
        /// 是否特色菜
        /// </summary>
        [Column("IsSpecial", DbType.Int32, false, false)]
        public int IsSpecial { get; set; }

        /// <summary>
        /// 排序1~100，越小越靠前
        /// </summary>
        [Column("OrderNum", DbType.Int32, false, false)]
        public int OrderNum { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark", DbType.String, false, false)]
        public string Remark { get; set; }

    }
}
