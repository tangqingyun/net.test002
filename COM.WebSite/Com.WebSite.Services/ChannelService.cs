using Com.WebSite.DataAccess;
using Com.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.WebSite.Services
{
    public class ChannelService
    {
        ChannelDataProvider dbProvider = new ChannelDataProvider();
        public ChannelService()
        {

        }

        public bool AddChannel(Entity_Channel entity)
        {
            return dbProvider.AddChannel(entity);
        }

        public bool CheckChannelExtis(string channelName, int reid)
        {
            return dbProvider.CheckChannelExtis(channelName, reid);
        }

        public bool UpdateChannel(Entity_Channel entity)
        {
            return dbProvider.UpdateChannel(entity);
        }

        public bool DeleteChannelByID(int channelID)
        {
            return dbProvider.DeleteChannelByID(channelID);
        }

        public IEnumerable<Entity_Channel> GetChannelListByReid(int reid = 0, int isHidden = -1)
        {
            return dbProvider.GetChannelListByReid(reid, isHidden);
        }

        public Entity_Channel GetChannelByChannelID(int channeld)
        {
            return dbProvider.GetChannelByChannelID(channeld);
        }


    }
}
