using Basement.Framework.Drawing;
using Basement.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Com.WebSite.Main.Ashx
{
    /// <summary>
    /// ValidateCode 的摘要说明
    /// </summary>
    public class ValidateCode : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var rndCode = CharTool.GenerateCheckCode(5);
            context.Session["rndCode"] = rndCode;
            new ImageVerification(rndCode,width:70,height:26,fettle:0,fontSize:15);
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