using Basement.Framework.Common;
using Com.WebSite.DataAccess;
using Com.WebSite.Models;
using Com.WebSite.Models.Entity;
using Com.WebSite.Models.Enum;
using Com.WebSite.Models.ParamterEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Com.WebSite.Services
{
    public class ArcticleService
    {
        ArcticleDataProvider dbProvider = new ArcticleDataProvider();
        public ArcticleService()
        {

        }

        public long AddArcticle(Entity_Arcticle arcticle, Entity_AddonArticle addon)
        {
            return dbProvider.AddArcticle(arcticle, addon);
        }

        public bool UpdateArcticle(Entity_FullArcticle entity)
        {
            return dbProvider.UpdateArcticle(entity);
        }

        public bool DeleteArcticle(long id)
        {
            return dbProvider.DeleteArcticle(id);
        }

        public bool BatchDeteArcticle(List<long> arr)
        {
            if (arr.Count == 0)
                return false;

            for (int i = 0; i < arr.Count; i++)
            {
                DeleteArcticle(arr[i]);
            }
            return true;
        }


        /// <summary>
        /// 更新文章自定义属性
        /// </summary>
        /// <param name="arrid">文章ID</param>
        /// <param name="flag">属性标识</param>
        /// <returns></returns>
        public bool UpdateArcticleFlags(string arrid, string flag)
        {
            return dbProvider.UpdateArcticleFlags(arrid, flag);
        }
        /// <summary>
        /// 更新文章图片
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public bool DeleteArcticleImg(long aid)
        {
            Entity_Arcticle model = dbProvider.SelectArcticleByID(aid);
            if (model == null)
            {
                return false;
            }
            bool bol = dbProvider.UpdateArcticleImg(aid);
            if (bol)
            {
                File.Delete(SysBaseHandle.ROOT_DIR + model.LitPic);
                File.Delete(SysBaseHandle.ROOT_DIR + model.ThumPic);
            }
            return true;
        }

          /// <summary>
        /// 更新文章点击数量
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public bool UpdateArcticleClick(long aid)
        {
            return dbProvider.UpdateArcticleClick(aid);
        }

        /// <summary>
        /// 获取滚动文章
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="place"></param>
        /// <returns></returns>
        public Entity_Arcticle GetArcicleScroll(long aid, EnumArticlePlace place)
        {
            return dbProvider.GetArcicleScroll(aid, place);
        }

        /// <summary>
        /// 根据ID获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity_Arcticle SelectArcticleByID(long aid)
        {
            return dbProvider.SelectArcticleByID(aid);
        }
        /// <summary>
        /// 根据ID获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity_FullArcticle GetArcticleByID(long aid)
        {
            return dbProvider.GetArcticleByID(aid);
        }


        /// <summary>
        /// 根据频道获取文章列表
        /// </summary>
        /// <param name="top">取几条</param>
        /// <param name="channelid">频道ID</param>
        /// <returns></returns>
        public IEnumerable<Entity_ArcticleList> GetArcticleListByChannelID(int top, int channelid)
        {
            return dbProvider.GetArcticleListByChannelID(top, channelid);
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
            return dbProvider.GetArcticlePager(query, index, size, out  pager);
        }

        /// <summary>
        /// 根据自定义属性获取文章
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="channelid">频道ID</param>
        /// <returns></returns>
        public IEnumerable<Entity_Arcticle> GetArcticleListByFlag(string[] flags, int channelid)
        {
            return dbProvider.GetArcticleListByFlag(flags);
        }

    }
}
