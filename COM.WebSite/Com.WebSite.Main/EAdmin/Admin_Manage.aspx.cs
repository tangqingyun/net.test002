using Basement.Framework.Security;
using Basement.Framework.Utility;
using Basement.Framework.Web;
using Com.WebSite.Models.Attributes;
using Com.WebSite.Models.Entity;
using Com.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.WebSite.Main.EAdmin
{
     [BasicAuthAttribute]
    public partial class Admin_Manage : EBasePage<Admin_Manage>
    {
        private readonly AdminService _AdminService = InstanceService.GetAdminServiceInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.Form["action"];
            switch (action)
            {
                case "edit":
                    SaveAdmin();
                    break;
                case "del":
                    DelAdmin();
                    break;
                default:
                    break;
            }

            if (!IsPostBack)
            {
                InitPageData();
            }

        }

        protected void InitPageData()
        {
            int index = 1;
            int size = 10000;
            int total = 0;
            this.repData.DataSource = _AdminService.GetAdminPager(null, index, size, out total);
            this.repData.DataBind();
            var roleList = _AdminService.GetAdminTypeList();
            ControlsExtension.BindDropDown(TypeID, roleList, "TypeName", "ID", new ListItem("选择角色", "0"));
        }

        protected void SaveAdmin()
        {
           
            Entity_Admin admin = RequestAsModel<Entity_Admin>();
            if (!ModelState.IsValid)
            {
                Response.Write("N");
            }
            admin.Pwd = MD5Util.GetMD5Hash(admin.Pwd);
            admin.CreateBy = LoginUser.ID;
            admin.UpdateBy = LoginUser.ID;

            bool bol = false;
            if (admin.ID == Guid.Empty)
            {
                admin.ID = Guid.NewGuid();
                admin.LoginIP = ClientIP.GetUserIP();
                admin.LastLoginTime = DateTimeTool.BackSqlServerMinDatetime();
                bol = _AdminService.AddAdmin(admin);
            }
            else
            {
                bol = _AdminService.UpdateAdminByID(admin);
            }
            Response.Write(bol ? "Y" : "N");
        }

        protected void DelAdmin()
        {
            string id = Request.Form["id"];
            Guid adminId;
            if (!Guid.TryParse(id, out adminId))
            {
                Response.Write("N");
            }
            bool b = _AdminService.DeleteAdmin(adminId);
            Response.Write(b ? "Y" : "N");
        }
    }
}