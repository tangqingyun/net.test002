using Com.WebSite.Models.Attributes;
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
    public partial class Role_Manage : System.Web.UI.Page
    {
        private readonly AdminService _AdminService=InstanceService.GetAdminServiceInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                this.repData.DataSource = _AdminService.GetAdminTypeList();
                this.repData.DataBind();
            }
        }

    }
}