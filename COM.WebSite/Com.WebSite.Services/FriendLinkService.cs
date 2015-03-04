using Com.WebSite.DataAccess;
using Com.WebSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.WebSite.Services
{
    public class FriendLinkService
    {
        FriendLinkDataProvider dbProvider = new FriendLinkDataProvider();
        public FriendLinkService()
        {

        }

        public bool AddFriendLink(Entity_FriendLink entity)
        {
            return dbProvider.AddFriendLink(entity);
        }

        public bool UpdateFriendLink(Entity_FriendLink entity)
        {
            return dbProvider.UpdateFriendLink(entity);
        }

        public bool DeleteByID(int id)
        {
            return dbProvider.DeleteByID(id);
        }
        public Entity_FriendLink GetFriendLinkByID(int id)
        {
            return dbProvider.GetFriendLinkByID(id);
        }
        public IEnumerable<Entity_FriendLink> GetFriendLinkList(int top)
        {
            return dbProvider.GetFriendLinkList(top);
        }

    }
}
