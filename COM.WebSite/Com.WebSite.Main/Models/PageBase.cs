using Basement.Framework.Web;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Com.WebSite.Main.Models
{
    public class PageBase : BasePage
    {
        /// <summary>
        /// 当前页
        /// </summary>
        protected  int Index
        {
            get
            {
                int pageIndex;
                if (!int.TryParse(GetQueryString("p"), out pageIndex))
                {
                    pageIndex = 1;
                }
                return pageIndex;
            }
        }
        /// <summary>
        /// 每页显示条数
        /// </summary>
        protected  static int PageSize
        {
            get
            {
                string size = Basement.Framework.Configuration.FrameworkConfig.GetAppSetting("PageSize");
                return Convert.ToInt32(size);
            }
        }

    }
}