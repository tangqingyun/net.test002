using Com.WebSite.Main.Models;
using Com.WebSite.Models.Attributes;
using Com.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.WebSite.Main.EAdmin
{
    [BasicAuthAttribute]
    public partial class Sys_Info : EBasePage<Sys_Info>
    {
        readonly SysInfoService _SysInfoService = InstanceService.GetSysInfoInstance();
        protected SysConfig config;
        protected void Page_Load(object sender, EventArgs e)
        {
            config = new Com.WebSite.Main.Models.SysConfig();
            if (IsPostBack)
            {
                Save();
            }
        }


        public void Save()
        {
            NameValueCollection collection = Request.Form;
            string[] arr = collection.AllKeys;
            if (arr.Length == 0)
            {
                return ;
            }
            IDictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < arr.Length; i++)
            {
                string value = collection.Get(i);
                dic.Add(arr[i], value);
            }
            _SysInfoService.Save(dic);
            ClientScriptAlert("保存成功", true);
        }

    }
}