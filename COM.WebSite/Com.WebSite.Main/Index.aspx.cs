using Com.WebSite.Models;
using Com.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.WebSite.Main
{

    public partial class Index:System.Web.UI.Page
    {
        //data-module="10001"
        ArcticleService _ArcticleService = new ArcticleService();
        ChannelService _ArctypeServices = new ChannelService();
        protected Entity_Channel channel = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //channel = _ArctypeServices.GetChannelByID(1006);
            }
        }

      

    }

}