using Com.WebSite.Main.Models;
using Com.WebSite.Models.Entity;
using Com.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Com.WebSite.Main.Ashx
{
    /// <summary>
    /// Arcticle_Manage 的摘要说明
    /// </summary>
    public class Arcticle_Manage : BaseHandler
    {
        private readonly ArcticleService _ArcticleService = InstanceService.GetArcticleServiceInstance();
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
                    result = DeleteArcticle();
                    break;
                case "delLitPic":
                    result = DeleteLitPic();
                    break;
                case "adArc":
                    result = RecommendArcticle();
                    break;
                case "delArc":
                    result = BatchDeleteArcticle();
                    break;
                default:
                    break;
            }
            Response.Write(result);
        }

        public string DeleteArcticle()
        {
            long aid;
            if (!long.TryParse(Request.Form["AId"], out aid))
            {
                return "参数非法";
            }
            bool bol = _ArcticleService.DeleteArcticle(aid);
            return bol.ToString();
        }

        public string DeleteLitPic()
        {
            long aid;
            if (!long.TryParse(Request.Form["aid"], out aid))
            {
                return "参数非法";
            }
            bool bol = _ArcticleService.DeleteArcticleImg(aid);
            return bol.ToString();
        }

        public string RecommendArcticle()
        {
            string arrid = Request.Form["AId"];
            bool bol = _ArcticleService.UpdateArcticleFlags(arrid, "c");
            return bol.ToString();
        }

        public string BatchDeleteArcticle()
        {
            string arrid = Request.Form["AId"];
            List<long> arrAid = new List<long>();
            string[] arr = arrid.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                long id;
                if (long.TryParse(arr[i], out id))
                {
                    arrAid.Add(id);
                }
            }
            bool bol = _ArcticleService.BatchDeteArcticle(arrAid);
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