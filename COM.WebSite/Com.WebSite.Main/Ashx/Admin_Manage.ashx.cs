using Com.WebSite.Main.EAdmin;
using Com.WebSite.Main.Models;
using Com.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Com.WebSite.Main.Ashx
{
    /// <summary>
    /// Admin_Manage 的摘要说明
    /// </summary>
    public class Admin_Manage : BaseHandler
    {

        private readonly AdminService _ArcticleService = InstanceService.GetAdminServiceInstance();
        HttpRequest Request;
        HttpResponse Response;
        public override void ProcessRequest(HttpContext context)
        {
           
            base.ProcessRequest(context);

            Request = context.Request;
            Response = context.Response;
            var action = Request.Form["do"];
            string result = "False";
            switch (action)
            {
                case "add":
                    break;
                case "out":
                    result=OutLogin(context);
                    break;
                default:
                    break;
            }
            Response.Write(result);
        }

        private string OutLogin(HttpContext context)
        {
            var session = context.Session["LoginUser"];
            if (session == null)
            {
                return "N";
            }
            context.Session["LoginUser"] = null;
            return "Y";
        }

        public override bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}