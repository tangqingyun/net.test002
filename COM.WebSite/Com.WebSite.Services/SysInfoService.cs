using Com.WebSite.DataAccess;
using Com.WebSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.WebSite.Services
{
    public class SysInfoService
    {
        SysInfoDataProvider dbProvider = new SysInfoDataProvider();
        public SysInfoService()
        {

        }

        public bool Save(IDictionary<string, string> dic)
        {
            return dbProvider.Save(dic);
        }

        public IEnumerable<Entity_SysInfo> SelectSysInfoList()
        {
            return dbProvider.SelectSysInfoList();
        }

          /// <summary>
        /// 根据变量名获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Entity_SysInfo SelectSysInfoByName(string name)
        {
            return dbProvider.SelectSysInfoByName(name);
        }
       
    }
}
