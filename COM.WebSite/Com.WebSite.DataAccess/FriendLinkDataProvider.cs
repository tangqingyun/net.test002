using Basement.Framework.Data;
using Com.WebSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Com.WebSite.DataAccess
{
    public class FriendLinkDataProvider
    {
        IDatabase database = Database.DbConnection;
        public FriendLinkDataProvider()
        {

        }

        public bool AddFriendLink(Entity_FriendLink entity)
        {
            int n = database.Insert<Entity_FriendLink>(entity);
            return n > 0 ? true : false;
        }

        public bool UpdateFriendLink(Entity_FriendLink entity)
        {
            string sql = "UPDATE TB_FriendLink SET Url=@Url, WebName=@WebName, SortRank=@SortRank, Logo=@Logo, TypeID=@TypeID,Email=@Email,Description=@Description, Ischeck=@Ischeck, UpdateBy=@UpdateBy, UpdateTime=@UpdateTime WHERE ID=@ID";
            IList<DbParameter> paramList = new List<DbParameter>() { 
                new SqlParameter("Url",entity.Url),
                new SqlParameter("WebName",entity.WebName),
                new SqlParameter("SortRank",entity.SortRank),
                new SqlParameter("Logo",entity.Logo),
                new SqlParameter("TypeID",entity.TypeID),
                new SqlParameter("Email",entity.Email),
                new SqlParameter("Description",entity.Description),
                new SqlParameter("Ischeck",entity.Ischeck),
                new SqlParameter("UpdateBy",entity.UpdateBy),
                new SqlParameter("UpdateTime",entity.UpdateTime),
                new SqlParameter("ID",entity.ID),
            };
            return database.ExecuteNoQuery(sql, paramList);
        }

        public bool DeleteByID(int id) {
            string sql = "DELETE FROM TB_FriendLink WHERE ID=@ID";
            IList<DbParameter> paramList = new List<DbParameter>() { 
                new SqlParameter("ID",id),
            };
            return database.ExecuteNoQuery(sql, paramList);
        }

        public Entity_FriendLink GetFriendLinkByID(int id) {
            string sql = "SELECT * FROM TB_FriendLink WHERE ID=@ID";
            IList<DbParameter> paramList = new List<DbParameter>() { 
                new SqlParameter("ID",id),
            };
            return database.SingleAsModel<Entity_FriendLink>(sql, paramList);
        }

        public IEnumerable<Entity_FriendLink> GetFriendLinkList(int top)
        {
            string sql = string.Format("SELECT TOP {0} * FROM TB_FriendLink", top);
            return database.ExecuteList<Entity_FriendLink>(sql, null);
        }
    }
}
