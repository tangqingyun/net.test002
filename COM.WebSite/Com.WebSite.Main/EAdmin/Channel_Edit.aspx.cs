using Com.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Basement.Framework.Web;
using Com.WebSite.Services;
using Com.WebSite.Models.Attributes;
namespace Com.WebSite.Main.EAdmin
{
     [BasicAuthAttribute]
    public partial class Channel_Edit : EBasePage<Channel_Edit>
    {
        private readonly ChannelService _ChannelService = InstanceService.GetChannelServiceInstance();
        protected int channelId;
        protected Entity_Channel model = new Entity_Channel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitPageData();
            }
            else
            {
                SaveChannel();
            }

        }

        private void InitPageData()
        {
            int.TryParse(GetQueryString("channelID"), out channelId);
            if (channelId != 0)
            {
                model = _ChannelService.GetChannelByChannelID(channelId);
            }

        }

        private void SaveChannel()
        {

            Entity_Channel channel = base.RequestAsModel<Entity_Channel>();
            if (!ModelState.IsValid)
            {
                var values = ModelState.Errors.FirstOrDefault();
                ClientScriptAlert(values.ErrorMessage);
                return;
            }
            channel.CreateBy = LoginUser.ID;
            channel.UpdateBy = LoginUser.ID;
            bool success = false;
            if (channel.ChannelID == 0)
            {
                bool bol = _ChannelService.CheckChannelExtis(channel.ChannelName, channel.Reid);
                if (bol)
                {
                    ClientScriptAlert("栏目已存在"); return;
                }
                success = _ChannelService.AddChannel(channel);
            }
            else
            {
                success=_ChannelService.UpdateChannel(channel);
            }
            string msg = string.Format("<script>alert('{0}');window.parent.closeSelectedTab()</script>", success ? "保存成功" : "保存失败");
            ClientScriptAlert(msg, false);
        }

    }
}