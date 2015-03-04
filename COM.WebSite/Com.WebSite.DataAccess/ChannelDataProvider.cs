using Basement.Framework.Data;
using Com.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Com.WebSite.DataAccess
{
    public class ChannelDataProvider
    {
        IDatabase database = Database.DbConnection;
        public ChannelDataProvider()
        {

        }

        public bool AddChannel(Entity_Channel entity)
        {
            int n = database.Insert<Entity_Channel>(entity);
            return n > 0 ? true : false;
        }

        public bool UpdateChannel(Entity_Channel entity)
        {
            string sql = @"UPDATE YN_Channel SET Reid=@Reid, SortRank=@SortRank, ChannelName=@ChannelName, IsHidden=@IsHidden, Keywords=@Keywords, Description=@Description, Content=@Content, IndexPage=@IndexPage, ListPage=@ListPage, DetailPage=@DetailPage, UpdateBy=@UpdateBy, UpdateTime=@UpdateTime,FileDir=@FileDir,SEOTitle=@SEOTitle WHERE ChannelID=@ChannelID";
            IList<DbParameter> paramList = new List<DbParameter>() { 
                new SqlParameter("Reid",entity.Reid),
                new SqlParameter("SortRank",entity.SortRank),
                new SqlParameter("ChannelName",entity.ChannelName),
                new SqlParameter("IsHidden",entity.IsHidden),
                new SqlParameter("Keywords",entity.Keywords),
                new SqlParameter("Description",entity.Description),
                new SqlParameter("Content",entity.Content),
                new SqlParameter("IndexPage",entity.IndexPage),
                new SqlParameter("ListPage",entity.ListPage),
                new SqlParameter("DetailPage",entity.DetailPage),
                new SqlParameter("UpdateBy",entity.UpdateBy),
                new SqlParameter("UpdateTime",entity.UpdateTime),
                new SqlParameter("FileDir",entity.FileDir),
                new SqlParameter("SEOTitle",entity.SEOTitle),
                new SqlParameter("ChannelID",entity.ChannelID)
            };
            return database.ExecuteNoQuery(sql, paramList);
        }

        public bool DeleteChannelByID(int channelID)
        {
            string sql = "DELETE FROM YN_Channel WHERE ChannelID=@channelID";
            IList<DbParameter> paramList = new List<DbParameter>() { 
                new SqlParameter("ChannelID",channelID),
               };
            return database.ExecuteNonQuery(sql, paramList) > 0 ? true : false;
        }

        public IEnumerable<Entity_Channel> GetChannelListByReid(int reid = 0, int isHidden = -1)
        {
            string sql = string.Format("SELECT * FROM YN_Channel WHERE Reid=@Reid {0} ORDER BY SortRank ASC",
                isHidden > 0 ? "AND IsHidden=" + isHidden: string.Empty);
            IList<DbParameter> paramList = new List<DbParameter>() { 
                new SqlParameter("Reid",reid),
               };
            return database.ExecuteList<Entity_Channel>(sql, paramList);
        }

        public Entity_Channel GetChannelByChannelID(int id)
        {
            string sql = "SELECT * FROM YN_Channel WHERE ChannelID=@ChannelID";
            IList<DbParameter> paramList = new List<DbParameter> { 
             new SqlParameter("ChannelID",id)
            };
            return database.SingleAsModel<Entity_Channel>(sql, paramList);
        }

        public bool CheckChannelExtis(string channelName, int reid)
        {
            string sql = "SELECT COUNT(1) FROM YN_Channel WHERE ChannelName=@ChannelName AND Reid=@Reid";
            IList<DbParameter> paramList = new List<DbParameter> { 
             new SqlParameter("ChannelName",channelName),
             new SqlParameter("Reid",reid),
            };
            int n = database.ExecuteScalar<int>(sql, paramList);
            return n > 0 ? true : false;
        }

    }
}
