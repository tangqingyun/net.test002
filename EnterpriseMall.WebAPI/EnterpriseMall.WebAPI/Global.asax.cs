using EnterpriseMall.WebAPI.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EnterpriseMall.WebAPI
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : Uni2uni.Framework.Mvc.BaseWebApiApplication
    {
        protected void Application_Start()
        {
            base.ApplicationStart();
        }
    }
}