using Com.WebSite.Models.Entity;
using Com.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.WebSite.Main.Utils
{
    public class SiteConfig
    {
        SysInfoService _SysInfoService = InstanceService.GetSysInfoInstance();
        public Entity_SysInfo this[string name]
        {
            get
            {
                Entity_SysInfo sys = _SysInfoService.SelectSysInfoByName(name);
                return sys == null ? new Entity_SysInfo() : sys;
            }
        }
       
    }
}