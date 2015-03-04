using Com.WebSite.Main.Models;
using Com.WebSite.Models.Entity;
using Com.WebSite.Models.ParamterEntity;
using Com.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Com.WebSite.Main.Ashx
{
    /// <summary>
    /// Article 的摘要说明
    /// </summary>
    public class Article : BaseHandler
    {
        private readonly ArcticleService _ArcticleService = InstanceService.GetArcticleServiceInstance();
        HttpRequest Request;
        HttpResponse Response;
        int pageSize = 10;
        public override void ProcessRequest(HttpContext context)
        {
            Request = context.Request;
            Response = context.Response;
            string action = Request.Form["do"];
            switch (action)
            {
                case "pager":
                    LoadArcticlePager();
                    break;
                case "pv":
                    CalculateArcticlePV();
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 加载文章分页数据
        /// </summary>
        private void LoadArcticlePager()
        {
            string index = Request.Form["index"];
            string channelid = Request.Form["channel"];
            string size = Request.Form["size"];
            ArticleQueryParam query = null;
            Entity_Pager pager;
            int channelID;
            if (int.TryParse(channelid, out channelID))
            {
                query = new ArticleQueryParam();
                query.ChannelID = channelID;
            }
            int.TryParse(size, out pageSize);
            IEnumerable<Entity_FullArcticle> list = _ArcticleService.GetArcticlePager(query, Convert.ToInt32(index), pageSize, out pager);
            string json = new JavaScriptSerializer().Serialize(list);
            Response.Write(json);
        }

        private void CalculateArcticlePV() {
            long aid;
            if (!long.TryParse(Request.Form["aid"], out aid)) {
                Response.Write("N");
            }
            bool bol=_ArcticleService.UpdateArcticleClick(aid);
            Response.Write(bol?"Y":"N");
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