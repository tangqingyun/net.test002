using Com.WebSite.Models.Entity;
using Com.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.WebSite.Main
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        protected ArcticleService _ArcticleService = InstanceService.GetArcticleServiceInstance();
        protected Entity_FullArcticle model = new Entity_FullArcticle();
        protected void Page_Load(object sender, EventArgs e)
        {
            long aid;
            if (!long.TryParse(Request.QueryString["aid"], out aid))
            {
                Response.Redirect("index.aspx");
            }
            model=_ArcticleService.GetArcticleByID(aid);
        }
    }
}