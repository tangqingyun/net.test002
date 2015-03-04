using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uni2uni.script.model
{
    /// <summary>
    /// 字段属性
    /// </summary>
    public class Column
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string Sequence { set; get; }

        private string Key { set; get; }

        /// <summary>
        /// 列名
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Tag { set; get; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { set; get; }
        public string Byte { set; get; }
        /// <summary>
        /// 长度
        /// </summary>
        public string Length { set; get; }

        /// <summary>
        /// 精确位数
        /// </summary>
        public string DecimalDigits { set; get; }
        public string NullTag { set; get; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { set; get; }
        /// <summary>
        /// 列描述
        /// </summary>
        public string ColumnDesc { set; get; }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool Majorkey
        {
            get
            {
                return Key == "yes" ? true : false;
            }
        }

        /// <summary>
        /// 是否是字符串类型
        /// </summary>
        public bool IsStringType
        {
            get {
                switch (Type.ToLower())
                {
                    case "uniqueidentifier":
                    case "char":
                    case "varchar":
                    case "nvarchar":
                    case "text":
                    case "nchar":
                    case "datetime":
                        return true;
                    default:
                        return false;
                }
            }
        }

    }
}
