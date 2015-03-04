using Com.WebSite.DataAccess;
using Com.WebSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.WebSite.Services
{
    public class FlagService
    {
        FlagDataProvider dbProvider = new FlagDataProvider();
        public FlagService()
        {

        }

        public IEnumerable<Entity_Flag> GetFlagList()
        {
            return dbProvider.GetFlagList();
        }
    }
}
