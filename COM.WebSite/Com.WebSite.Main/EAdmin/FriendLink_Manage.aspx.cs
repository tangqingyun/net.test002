using Com.WebSite.Models.Attributes;
using Com.WebSite.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.WebSite.Main.EAdmin
{
     [BasicAuthAttribute]
    public partial class FriendLink_Manage : EBasePage<FriendLink_Manage>
    {
        private readonly FriendLinkService _FriendLinkService = InstanceService.GetInstance<FriendLinkService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GetForm("action") == "del") {
                int id;
                if (int.TryParse(GetForm("id"), out id)) {
                    var model=_FriendLinkService.GetFriendLinkByID(id);
                    if (model == null) {
                        Response.Write("N");
                        Response.End();
                    }

                    bool bol = _FriendLinkService.DeleteByID(id);
                    if (bol) {
                        File.Delete(MapPath(model.Logo));
                    }
                    Response.Write(bol?"Y":"N");
                    Response.End();
                }
            }

        }
    }
}