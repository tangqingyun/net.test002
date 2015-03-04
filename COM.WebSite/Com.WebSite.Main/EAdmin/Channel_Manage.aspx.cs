using Com.WebSite.Models;
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
    public partial class Channel_Manage : System.Web.UI.Page
    {
        protected readonly ChannelService _ChannelService = InstanceService.GetChannelServiceInstance();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) {
                BindChannelTree();
            }
        }


        protected void BindChannelTree() {

            //IEnumerable<Entity_Channel> rootList= _ChannelService.GetChannelListByReid();
            //rpTree.DataSource = rootList;
            //rpTree.DataBind();
        }

    }
}