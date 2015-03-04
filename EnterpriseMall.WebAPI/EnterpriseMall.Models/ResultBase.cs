using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMall.Models
{
    /// <summary>
    /// 返回结果公用类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class ResultBase<T> where T : class, new()
    {
        /// <summary>
        /// 返回实体
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string errmsg { get; set; }

        private string State = "0";
        /// <summary>
        /// 返回状态 0为成功 1失败 -1异常 其它根据业务需求自定义
        /// </summary>
        public string state
        {
            get { return State; }
            set { State = value; }
        }

    }
}
