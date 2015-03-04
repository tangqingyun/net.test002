using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Com.WebSite.Main.Models
{
    public class BaseHandler : IRequiresSessionState, IHttpHandler
    {
      
        public virtual void ProcessRequest(HttpContext context)
        {
            if (context.Session["LoginUser"] == null)
            {
                //context.Response.Write("无访问权限");
                //context.Response.End();
                //return;
            }
        }

        public virtual bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

    }
}