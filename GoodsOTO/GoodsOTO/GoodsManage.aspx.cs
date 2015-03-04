using Basement.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodsOTO
{
    public partial class GoodsManage : System.Web.UI.Page
    {
        IDatabase onlineBll = Database.OnLine_Goodsinfo;
        protected void Page_Load(object sender, EventArgs e)
        {
           //   onlineBll.
        }
    }
}