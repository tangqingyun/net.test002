using Com.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.WebSite.Main.Models
{
    public class EAService
    {

        public static AdminService GetAdminServiceInstance
        {
            get
            {
                return new AdminService();
            }
        }

        public static ArcticleService GetArcticleServiceInstance
        {
            get
            {
                return new ArcticleService();
            }

        }

        public static ChannelService GetChannelServiceInstance
        {
            get
            {
                return new ChannelService();
            }

        }

    }
}