using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.WebSite.Services
{
    public sealed class InstanceService
    {
        public static AdminService GetAdminServiceInstance()
        {
            return new AdminService();
        }

        public static ArcticleService GetArcticleServiceInstance()
        {
            return new ArcticleService();
        }

        public static ChannelService GetChannelServiceInstance()
        {
            return new ChannelService();
        }

        public static SysInfoService GetSysInfoInstance()
        {
            return new SysInfoService();
        }

        public static FlagService GetFlagInstance()
        {
            return new FlagService();
        }

        public static FriendLinkService GetFriendLinkInstance()
        {
            return new FriendLinkService();
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetInstance<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
