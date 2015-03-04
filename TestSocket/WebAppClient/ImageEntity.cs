using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppClient
{
    [Serializable]
    public class ImageEntity
    {
        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImageName { set; get; }
        /// <summary>
        /// 图片二进制数据
        /// </summary>
        public byte[] ImageByte { set; get; }
        /// <summary>
        /// 图片大小
        /// </summary>
        public int Size { set; get; }
    }
}