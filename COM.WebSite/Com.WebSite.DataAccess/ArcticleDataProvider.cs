using Basement.Framework.Data;
using Com.WebSite.Models.Entity;
using Com.WebSite.Models.Enum;
using Com.WebSite.Models.ParamterEntity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Com.WebSite.DataAccess
{
    public class ArcticleDataProvider
    {
        IDatabase database = Database.DbConnection;
        public ArcticleDataProvider()
        {

        }

        public long AddArcticle(Entity_Arcticle model, Entity_AddonArticle addon)
        {
            object obj = database.InsertIdentity<Entity_Arcticle>(model);
            if (obj == null)
            {
                return 0;
            }
            long aid = Convert.ToInt64(obj);
            addon.ArcticleID = aid;
            int n = database.Insert<Entity_AddonArticle>(addon);
            return aid;
        }

        public bool UpdateArcticle(Entity_FullArcticle entity)
        {
            IDictionary<string, IList<DbParameter>> dic = new Dictionary<string, IList<DbParameter>>();
            string script1 = @"UPDATE YN_Arcticle SET 
            ChannelID=@ChannelID, 
            Title=@Title, 
            Writer=@Writer,
            Tags=@Tags,
            Source=@Source, 
            Flag=@Flag, 
            LitPic=@LitPic, 
            ThumPic=@ThumPic, 
            Keywords=@Keywords, 
            [Description]=@Description, 
            Click=@Click, 
            StaticPath=@StaticPath,
            UpdateBy=@UpdateBy,
            UpdateTime=@UpdateTime,
            RedireUrl=@RedireUrl,
            IsHtml=@IsHtml,
            FileName=@FileName
            WHERE ArcticleID=@ArcticleID";
            IList<DbParameter> listParame1 = new List<DbParameter> { 
                 new SqlParameter("ChannelID", entity.ChannelID),
                 new SqlParameter("Title", entity.Title),
                 new SqlParameter("Writer", entity.Writer),
                 new SqlParameter("Tags", entity.Tags),
                 new SqlParameter("Source", entity.Source),
                 new SqlParameter("Flag", entity.Flag),
                 new SqlParameter("LitPic", entity.LitPic),
                 new SqlParameter("ThumPic", entity.ThumPic),
                 new SqlParameter("Keywords", entity.Keywords),
                 new SqlParameter("Description", entity.Description),
                 new SqlParameter("Click", entity.Click),
                 new SqlParameter("StaticPath", entity.StaticPath),
                 new SqlParameter("UpdateBy", entity.UpdateBy),
                 new SqlParameter("UpdateTime", entity.UpdateTime),
                 new SqlParameter("RedireUrl", entity.RedireUrl),
                 new SqlParameter("IsHtml", entity.IsHtml),
                 new SqlParameter("FileName", entity.FileName),
                 new SqlParameter("ArcticleID", entity.ArcticleID)
             };
            dic.Add(script1, listParame1);
            string script2 = @"UPDATE YN_AddonArticle
SET Body=@Body WHERE ArcticleID=@ArcticleID";
            IList<DbParameter> listParame2 = new List<DbParameter> { 
                 new SqlParameter("ArcticleID", entity.ArcticleID),
                 new SqlParameter("Body", entity.Body)
             };

            dic.Add(script2, listParame2);
            return database.ExecuteTransation(dic);
        }
        /// <summary>
        /// 更新文章图片
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public bool UpdateArcticleImg(long aid)
        { 
            string sql = "UPDATE YN_Arcticle SET LitPic='',ThumPic='' WHERE ArcticleID=@ArcticleID";
            IList<DbParameter> listParame = new List<DbParameter>
            {
                new SqlParameter("ArcticleID", aid)
            };
            return database.ExecuteNoQuery(sql, listParame);
        }

        public bool DeleteArcticle(long id)
        {

            IDictionary<string, IList<DbParameter>> dic = new Dictionary<string, IList<DbParameter>>();
            string script1 = "DELETE FROM YN_Arcticle WHERE ArcticleID=@ArcticleID";
            IList<DbParameter> listParame1 = new List<DbParameter> { 
                 new SqlParameter("ArcticleID", id) 
             };
            dic.Add(script1, listParame1);
            string script2 = "DELETE FROM YN_AddonArticle WHERE ArcticleID=@ArcticleID";
            IList<DbParameter> listParame2 = new List<DbParameter> { 
                new SqlParameter("ArcticleID", id) 
            };
            dic.Add(script2, listParame2);
            return database.ExecuteTransation(dic);
        }

       
        /// <summary>
        /// 更新文章自定义属性
        /// </summary>
        /// <param name="arrid">文章ID</param>
        /// <param name="flag">属性标识</param>
        /// <returns></returns>
        public bool UpdateArcticleFlags(string arrid, string flag)
        {
            string sql = string.Format("UPDATE YN_Arcticle SET Flag=ISNULL(Flag,'')+',{0}' WHERE ArcticleID IN ({1})", flag, arrid);
            return database.ExecuteNoQuery(sql, null);
        }
        /// <summary>
        /// 更新文章点击数量
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public bool UpdateArcticleClick(long aid) {
            string script = "UPDATE  YN_Arcticle SET Click=Click+1 WHERE ArcticleID=@ArcticleID";
            IList<DbParameter> listParms = new List<DbParameter> { 
                 new SqlParameter("ArcticleID", aid) 
             };
            return database.ExecuteNoQuery(script,listParms);
        }
        /// <summary>
        /// 根据频道获取文章列表
        /// </summary>
        /// <param name="top">取几条</param>
        /// <param name="channelid">频道ID</param>
        /// <returns></returns>
        public IEnumerable<Entity_ArcticleList> GetArcticleListByChannelID(int top, int channelid)
        {
            string script = string.Format(@"SELECT TOP {0} AR.*,CHA.IndexPage,CHA.ListPage,CHA.DetailPage 
FROM dbo.YN_Arcticle AR WITH(NOLOCK) 
INNER JOIN dbo.YN_Channel CHA WITH(NOLOCK) ON AR.ChannelID=CHA.ChannelID  
WHERE AR.ChannelID=@ChannelID ORDER BY AR.CreateTime DESC", top);
            IList<DbParameter> listParame = new List<DbParameter>
            {
                new SqlParameter("ChannelID", channelid)
            };
            return database.ExecuteList<Entity_ArcticleList>(script, listParame);
        }

        /// <summary>
        /// 根据自定义属性获取文章
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        public IEnumerable<Entity_Arcticle> GetArcticleListByFlag(string[] flags, int channelid = 0)
        {
            if (flags.Length == 0)
            {
                return null;
            }
            StringBuilder script = new StringBuilder("SELECT  * FROM YN_Arcticle WHERE 1=1 ");
            if (channelid != 0)
            {
                script.Append(" AND ChannelID= " + channelid);
            }
            int len = flags.Length;
            for (int i = 0; i < len; i++)
            {
                if (i == 0)
                {
                    script.AppendFormat(" AND charindex('{0}',Flag)>0  ", flags[i]);
                }
                else
                {
                    script.AppendFormat(" {0} charindex('{1}',Flag)>0  ", i < len ? " OR " : string.Empty, flags[i]);
                }
            }
            return database.ExecuteList<Entity_Arcticle>(script.ToString(), null);
        }

        /// <summary>
        /// 获取滚动文章
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="place"></param>
        /// <returns></returns>
        public Entity_Arcticle GetArcicleScroll(long aid, EnumArticlePlace place)
        {
            string sql = string.Empty;
            if (place == EnumArticlePlace.Next)
            {
                sql = @"SELECT TOP 1 * FROM dbo.YN_Arcticle WHERE ArcticleID>@ArcticleID
ORDER BY ArcticleID ASC";
            }
            else
            {
                sql = @"SELECT TOP 1 * FROM dbo.YN_Arcticle WHERE ArcticleID<@ArcticleID
ORDER BY ArcticleID DESC";
            }
            IList<DbParameter> paramList = new List<DbParameter> { 
             new SqlParameter("ArcticleID",aid)
            };
            return database.SingleAsModel<Entity_Arcticle>(sql, paramList);
        }


        /// <summary>
        /// 根据ID获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity_Arcticle SelectArcticleByID(long aid)
        {
            string script = @"SELECT * FROM YN_Arcticle AR WITH(NOLOCK)
WHERE AR.ArcticleID=@ArcticleID";
            IList<DbParameter> paramList = new List<DbParameter> { 
             new SqlParameter("ArcticleID",aid)
            };
            return database.SingleAsModel<Entity_FullArcticle>(script, paramList);
        }

        /// <summary>
        /// 根据ID获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity_FullArcticle GetArcticleByID(long aid)
        {
            string script = @"SELECT AR.*,Cha.ChannelName,ADDO.Body FROM YN_Arcticle AR WITH(NOLOCK) 
INNER JOIN YN_AddonArticle ADDO WITH(NOLOCK) ON AR.ArcticleID=ADDO.ArcticleID
INNER JOIN dbo.YN_Channel Cha WITH(NOLOCK) ON Cha.ChannelID=AR.ChannelID
WHERE AR.ArcticleID=@ArcticleID";
            IList<DbParameter> paramList = new List<DbParameter> { 
             new SqlParameter("ArcticleID",aid)
            };
            return database.SingleAsModel<Entity_FullArcticle>(script, paramList);
        }


        /// <summary>
        /// 文章分页
        /// </summary>
        /// <param name="queyr"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public IEnumerable<Entity_FullArcticle> GetArcticlePager(ArticleQueryParam query, int index, int size, out Entity_Pager pager)
        {
            string exsql = BuilderScript(query, true);
            int total = database.ExecuteScalar<int>(exsql);
            pager = new Entity_Pager() { Index = index, Size = size, Total = total };
            return database.GetPageList<Entity_FullArcticle>(BuilderScript(query), "", "CreateTime DESC", index, size);
        }

        private string BuilderScript(ArticleQueryParam query, bool bol = false)
        {
            StringBuilder script = new StringBuilder();
            string fields = " AR.*,ADDO.Body,Cha.ChannelName";
            if (bol)
            {
                fields = "COUNT(1)";
            }
            script.AppendFormat(@"SELECT {0}  FROM YN_Arcticle AR WITH(NOLOCK)
INNER JOIN YN_AddonArticle ADDO WITH(NOLOCK) ON AR.ArcticleID=ADDO.ArcticleID 
INNER JOIN dbo.YN_Channel Cha WITH(NOLOCK) ON Cha.ChannelID=AR.ChannelID
WHERE 1=1 ", fields);
            if (query == null)
                return script.ToString();

            if (query.ChannelID != 0)
            {
                script.AppendFormat(" AND AR.ChannelID={0} ", query.ChannelID);
            }
            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                script.AppendFormat(" AND AR.Title LIKE '%{0}%'", query.Title);
            }
            return script.ToString();
        }

    }

}
