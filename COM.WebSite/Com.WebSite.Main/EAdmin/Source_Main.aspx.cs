using Basement.Framework.Common;
using Basement.Framework.IO;
using Com.WebSite.Models.Attributes;
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
    public partial class Source_Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = FolderExtension.GetDirectoryFiles(SysBaseHandle.ROOT_DIR, "*.aspx");
                repList.DataSource = list;
                repList.DataBind();
            }
        }

    }

 
}