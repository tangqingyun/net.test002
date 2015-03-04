using Basement.Framework.Configuration;
using Basement.Framework.Web;
using Com.WebSite.Models.Attributes;
using Com.WebSite.Models.Entity;
using Com.WebSite.Models.ParamterEntity;
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
    public partial class Arcticle_Manage : EBasePage<Arcticle_Manage>
    {
        private readonly ChannelService _ChannelService = InstanceService.GetChannelServiceInstance();
        private readonly ArcticleService _ArcticleService = InstanceService.GetArcticleServiceInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var channeList = _ChannelService.GetChannelListByReid();
                ControlsExtension.BindDropDown(ChannelID, channeList, "ChannelName", "ChannelID",
                    new ListItem("选择栏目", "0"));
                LoadArcticlePager();
            }
            else
            {
               
                ArticleQueryParam query = RequestAsModel<ArticleQueryParam>();
                if (!ModelState.IsValid)
                {
                    var values = ModelState.Errors.FirstOrDefault();
                    ClientScriptAlert(values.ErrorMessage);
                    return;
                }
                LoadArcticlePager(query);
            }

        }

        protected void LoadArcticlePager(ArticleQueryParam query = null)
        {
            int index =AspNetPager.CurrentPageIndex;//当前页
            int size = Convert.ToInt32(FrameworkConfig.GetAppSetting("eadminsize"));
            Entity_Pager pager;
            IEnumerable<Entity_FullArcticle> list = _ArcticleService.GetArcticlePager(query, index, size, out pager);
            AspNetPager.RecordCount = pager.Total;
            AspNetPager.PageSize = size;
            rpData.DataSource = list;
            rpData.DataBind();
            ViewState["query"] = query;
        }

        protected void AspNetPager_PageChanged(object sender, EventArgs e)
        {
            LoadArcticlePager(ViewState["query"] as ArticleQueryParam);
        }

    }
}