using Basement.Framework.Drawing;
using Basement.Framework.Security;
using Basement.Framework.Web;
using Com.WebSite.Main.Models;
using Com.WebSite.Main.Models.Request;
using Com.WebSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.WebSite.Main.EAdmin
{
    public partial class Login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //System.Diagnostics.Process pro = new System.Diagnostics.Process();
            ////显示窗口
            //pro.StartInfo.CreateNoWindow = true;
            //pro.StartInfo.UseShellExecute = false;
            ////要调用的控制台程序
            ////pro.StartInfo.FileName = HttpContext.Current.Server.MapPath("~/bin/TestHttpRequestLog.exe");
            // pro.StartInfo.FileName = @"C:\Users\Administrator\Desktop\示例项目\TestHttpRequestLog\TestHttpRequestLog\bin\Debug\TestHttpRequestLog.exe";
            ////给控制台程序的参数传递值
            //pro.StartInfo.Arguments = "dddddddd";
            //pro.Start();


            if (GetForm("action") == "LOGIN")
            {
                Response.Write(LoginCheck());
                Response.End();
            }

        }

        private int LoginCheck()
        {
           
            Login_Request model = RequestAsModel<Login_Request>();
            if (!ModelState.IsValid)
            {
                var values = ModelState.Errors.FirstOrDefault();
                return -1;
            }
            if (!Session["rndCode"].ToString().ToLower().Equals(model.RndCode.ToLower()))
            {
                return -1;
            }

            Entity_Admin admin = EAService.GetAdminServiceInstance.AdminLogin(model.Name, MD5Util.GetMD5Hash(model.Pwd));
            if (admin == null)
            {
                return 0;
            }
            Session.Add("LoginUser", admin);
            return 1;
        }

    }

   
}