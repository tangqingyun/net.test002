using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Com.WebSite.Models;
using Com.WebSite.Services;
using Com.WebSite.Models.Entity;
using System.Collections.Generic;
using Basement.Framework.Utility;
using Basement.Framework.Security;
using Com.WebSite.RazorEngine;

namespace COM.WebSite.UNit
{
    [TestClass]
    public class UnitTest1
    {

        private readonly ChannelService _ChannelServices = new ChannelService();
        private readonly ArcticleService _ArcticleService = new ArcticleService();
        private readonly AdminService _AdminService = new AdminService();
        [TestMethod]
        public void AddChannel()
        {
            Entity_Channel channel = new Entity_Channel
            {
                ChannelName = "测试一",
                Content = string.Empty,
                Description = string.Empty,
                IsHidden = false,
                Keywords = string.Empty,
                Reid = 0,
                SortRank = 0,
                IndexPage = string.Empty,
                ListPage = string.Empty,
                DetailPage = string.Empty
            };
            bool bol = _ChannelServices.AddChannel(channel);
            Assert.IsTrue(bol);
        }

        [TestMethod]
        public void DeleteChannelByID()
        {
            bool bol = _ChannelServices.DeleteChannelByID(1024);
            Assert.IsTrue(bol);
        }

        [TestMethod]
        public void UpdateChannel()
        {
            Entity_Channel channel = new Entity_Channel
            {
                ChannelID = 1023,
                ChannelName = "测试100",
                Content = "Content",
                Description = "Description",
                IsHidden = true,
                Keywords = "Keywords",
                Reid = 100,
                SortRank = 100,
                IndexPage = string.Empty,
                ListPage = string.Empty,
                DetailPage = string.Empty,
            };
            bool bol = _ChannelServices.UpdateChannel(channel);
            Assert.IsTrue(bol);

        }

        [TestMethod]
        public void AddArcticle()
        {
            Entity_Arcticle model = new Entity_Arcticle()
            {
                ChannelID = 1009,
                Click = 0,
                Description = "Description",
                Flag = "Flag",
                Keywords = "Keywords",
                LitPic = "",
                Source = "Source",
                StaticPath = "StaticPath",
                ThumPic = "",
                Title = "山东某某集团全面预算管理系统顺利上线运行",
                Writer = "Writer"
            };

            Entity_AddonArticle addon = new Entity_AddonArticle()
            {
                Body = @"<img src='http://imgcdn.ph.126.net/ECguRy5qSQ1BAIY2LC_49g==/3681692695475601563.jpg'/>正如近日多家媒体所报道，滴滴打车内部的确正在运营一个商务租车项目，巴人早在今年年初便获知，滴滴打车已拆分出一只技术团队专门负责商务租车项目，前期开发由出身百度的滴滴打车产品技术副总裁张博负责。而到年中，滴滴内部人士透露，该项目已单独拆分出一家公司运营，与原有打车app项目共同属于滴滴集团。而几乎与此同时，腾讯也派出一名负责市场公关的高层进驻滴滴负责该公司未来整体的市场工作任职滴滴市场副总裁，而由此也带来了滴滴又一次人事变化，据悉，此前供职于凡客的滴滴打车运营副总裁张晶已经离职，这是继沈威风离职后滴滴有一名“凡客系”副总裁离职。而一系列重组后，滴滴即将披上新战袍入侵商务租车市场，与快的旗下一号专车（原名大黄蜂）、易到等一较高下",
            };

            List<string> imgUrlList = HtmlTool.GetHtmlImageUrlList(addon.Body);
            if (imgUrlList.Count > 0)
            {
                model.LitPic = imgUrlList[0];
                model.ThumPic = imgUrlList[0];
            }
            long id= _ArcticleService.AddArcticle(model, addon);
            Assert.IsTrue(id>0?true:false);
        }

        [TestMethod]
        public void UpdateArcticle()
        {
            Entity_FullArcticle entity = new Entity_FullArcticle()
            {
                ArcticleID = 2117,
                ChannelID = 76,
                Click = 1,
                Description = "Description1",
                Flag = "Flag1",
                Keywords = "Keywords1",
                LitPic = "LitPic1",
                Source = "Source1",
                StaticPath = "StaticPath1",
                ThumPic = "ThumPic1",
                Title = "Title1",
                Writer = "Writer1",
                Body = "body1",
                UpdateBy = Guid.NewGuid(),
                UpdateTime = DateTime.Now
            };
            bool bol = _ArcticleService.UpdateArcticle(entity);
            Assert.IsTrue(bol);
        }

        [TestMethod]
        public void DeleteArcticle()
        {
            bool bol = _ArcticleService.DeleteArcticle(2117);
            Assert.IsTrue(bol);
        }


        [TestMethod]
        public void GetArcticlePager()
        {
            int index = 1;
            int size = 2;
            Entity_Pager pager;
            IEnumerable<Entity_FullArcticle> list = _ArcticleService.GetArcticlePager(null, index, size, out pager);
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void AddAdmin()
        {
            Entity_Admin admin = new Entity_Admin
            {
                Email = string.Empty,
                ID = Guid.NewGuid(),
                LastLoginTime = DateTimeTools.BackSqlServerMinDatetime(),
                LoginIP = ClientIP.GetUserIP(),
                Name = "123",
                Pwd = MD5Util.GetMD5Hash("123"),
                TypeID = 10
            };
            bool bol = _AdminService.AddAdmin(admin);
            Assert.IsTrue(bol);
        }

        [TestMethod]
        public void DeleteAdmin()
        {
            bool bol = _AdminService.DeleteAdmin(new Guid("FB711FC1-7669-4F18-9711-EA7DE46EB298"));
            Assert.IsTrue(bol);
        }

        [TestMethod]
        public void CreateArticelHtml()
        {
            HtmlEngine.CreateArticelHtml(100);
        }

    }
}
