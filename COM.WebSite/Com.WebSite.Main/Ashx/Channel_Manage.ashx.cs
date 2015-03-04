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
    /// Channel_Manage 的摘要说明
    /// </summary>
    public class Channel_Manage : BaseHandler
    {
        private readonly ChannelService _ChannelService = InstanceService.GetChannelServiceInstance();
        HttpRequest Request;
        HttpResponse Response;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            Request = context.Request;
            Response = context.Response;
            var action = Request.Form["ACTION"];
            string result = "False";
            switch (action)
            {
                case "del":
                    result = DeleteChannel();
                    break;
                default:
                    break;
            }
            Response.Write(result);
        }

        private string DeleteChannel()
        {
            int channelID;
            if (!int.TryParse(Request.Form["channelid"], out channelID))
            {
                return "参数非法";
            }
            bool bol = _ChannelService.DeleteChannelByID(channelID);
            return bol.ToString();
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