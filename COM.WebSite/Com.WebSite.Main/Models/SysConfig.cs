using Com.WebSite.Models.Entity;
using Com.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.WebSite.Main.Models
{
    public class SysConfig
    {

        public Entity_SysInfo this[string name]
        {
            get
            {
                Entity_SysInfo sysinfo = List.Where(m => m.Name == name).FirstOrDefault();
                if (sysinfo == null)
                {
                    return new Entity_SysInfo();
                }
                return sysinfo;
            }
        }

        private IEnumerable<Entity_SysInfo> List
        {
            get
            {
                return InstanceService.GetSysInfoInstance().SelectSysInfoList();
            }
        }
    }
}