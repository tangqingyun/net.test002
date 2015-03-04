using Basement.Framework.AttributeExt;
using Basement.Framework.Web;
using Com.WebSite.Models.Attributes;
using Com.WebSite.Models.Entity;
using Com.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.WebSite.Main.EAdmin
{
    public class EBasePage<T> : BasePage
    {
        /// <summary>
        /// 当前登陆用户
        /// </summary>
        public Entity_Admin LoginUser = null;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            bool bol = AttributesExt.ExitsAttributes<BasicAuthAttribute>(typeof(T));
            if (!bol) return;
            if (Session["LoginUser"] == null)
            {
                LoginUser = InstanceService.GetAdminServiceInstance().GetAdminByID(new Guid("83454480-7CB0-451B-8128-CAC48B0552B4"));
                //Response.Redirect("Login.aspx");
                return;
            }
            LoginUser = Session["LoginUser"] as Entity_Admin;
        }

        protected void ClientScriptAlert(string message,bool addtag=true)
        {
            if (addtag)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "alert('" + message + "')", addtag);
            }
            else {
                ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), message, addtag);
            }
        }

        protected void AlertMessage(string message)
        {
            string tipmsg = string.Format("<script>alert('{0}');window.parent.closeSelectedTab()</script>", message);
            ClientScriptAlert(tipmsg, false);
        }

    }
}