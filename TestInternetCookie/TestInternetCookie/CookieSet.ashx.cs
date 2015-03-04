using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestInternetCookie
{
    /// <summary>
    /// CookieSet 的摘要说明
    /// </summary>
    public class CookieSet : IHttpHandler
    {
        HttpRequest Request;
        HttpResponse Response;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Request = context.Request;
            Response = context.Response;
            string key = "name";
            string value = "100000000";
            string path = "/";
            string cookievalue = value + ";" + path + ";expires=Sun,22-Feb-2015 00:00:00 GMT";
            Common.IECookieHelper.SetInternetCookie("http://secure.ejoy365.com", key, cookievalue);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}