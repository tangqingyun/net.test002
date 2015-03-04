using Basement.Framework.Common;
using Basement.Framework.Drawing;
using Basement.Framework.Utility;
using Basement.Framework.Web;
using Com.WebSite.Main.Utils;
using Com.WebSite.Models.Attributes;
using Com.WebSite.Models.Entity;
using Com.WebSite.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.WebSite.Main.EAdmin
{
     [BasicAuthAttribute]
    public partial class Arcticle_Edit : EBasePage<Arcticle_Edit>
    {
        private readonly ChannelService _ChannelService = InstanceService.GetChannelServiceInstance();
        private readonly ArcticleService _ArcticleService = InstanceService.GetArcticleServiceInstance();
        private readonly SysInfoService _SysInfoService = InstanceService.GetSysInfoInstance();
        private readonly FlagService _FlagService = InstanceService.GetFlagInstance();

        protected Entity_FullArcticle model = new Entity_FullArcticle();

        protected long aid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitPageData();
            }
            else
            {
                SaveArcticle();
            }

        }

        protected void InitPageData()
        {
            //绑定自定义属性
            repFlag.DataSource = _FlagService.GetFlagList();
            repFlag.DataBind();
            var channeList = _ChannelService.GetChannelListByReid();
            ControlsExtension.BindDropDown(ChannelID, channeList, "ChannelName", "ChannelID", new ListItem("选择栏目", "0"));
            long.TryParse(GetQueryString("aid"), out aid);
            if (aid != 0)
            {
                model = _ArcticleService.GetArcticleByID(aid);
            }
        }

        protected void SaveArcticle()
        {
            Entity_FullArcticle model = base.RequestAsModel<Entity_FullArcticle>();
            if (!ModelState.IsValid)
            {
                var values = ModelState.Errors.FirstOrDefault();
                ClientScriptAlert(values.ErrorMessage);
                return;
            }
            model.CreateBy = LoginUser.ID;
            model.UpdateBy = LoginUser.ID;
            if (string.IsNullOrWhiteSpace(model.Writer)) {
                model.Writer = LoginUser.Name;
            }
            bool b = false;
            try
            {
                HttpPostedFile hf = Request.Files["ImgFile"];
                UploadThumPicture(model, hf);
                if (model.ArcticleID == 0)
                {
                    Entity_Arcticle Arcticle = new Entity_Arcticle()
                    {
                        ChannelID = model.ChannelID,
                        Click = model.Click,
                        Description = model.Description,
                        Flag = model.Flag,
                        Source = model.Source,
                        Title = model.Title,
                        Keywords = model.Keywords,
                        Writer = model.Writer,
                        LitPic = model.LitPic,
                        Tags = model.Tags,
                        ThumPic = model.ThumPic,
                        StaticPath = string.Empty,
                        RedireUrl = model.RedireUrl,
                        IsHtml = model.IsHtml,
                        FileName = model.FileName,
                        CreateBy = model.CreateBy,
                        UpdateBy = model.UpdateBy
                    };
                    Entity_AddonArticle Addon = new Entity_AddonArticle()
                    {
                        Body = model.Body,
                    };
                    long aid= _ArcticleService.AddArcticle(Arcticle, Addon);
                    b = aid > 0 ? true : false;
                }
                else
                {
                    b = _ArcticleService.UpdateArcticle(model);
                }
            }
            catch (Exception ex)
            {
                ClientScriptAlert(ex.Message.Replace("\"",""));
                return;
            }
            if (model.ArcticleID == 0)
            {
                ClientScriptAlert(b ? "保存成功" : "保存失败");
            }
            else {
                AlertMessage(b ? "修改成功" : "修改失败");
            }
        }

        /// <summary>
        /// 缩略图片上传
        /// </summary>
        /// <param name="model"></param>
        /// <param name="hf"></param>
        private void UploadThumPicture(Entity_FullArcticle model,HttpPostedFile hf)
        {
            if (hf == null || hf.ContentLength==0)
            {
                model.LitPic = Request.Form["hidLitPic"];
                model.ThumPic = Request.Form["hidThumPic"];
                return;
            }
            SiteConfig config = new SiteConfig();
            Entity_SysInfo sys = config["cfg_medias_dir"];
            Entity_SysInfo ddimgwidth = config["cfg_ddimg_width"];
            Entity_SysInfo ddimgheight = config["cfg_ddimg_height"];
            string extname = Path.GetExtension(hf.FileName);
            int ddwith=150;
            int ddheight = 150;
            int.TryParse(ddimgwidth.Value, out ddwith);
            int.TryParse(ddimgheight.Value, out ddheight);
            System.Drawing.Image image = System.Drawing.Image.FromStream(hf.InputStream);
            System.Drawing.Image thumImage = ImageExtension.GetThumbnailImageEx(image, ddwith, ddheight, true);
            string datetime = DateTime.Now.ToString("yyyyMMdd");
            model.LitPic = sys.Value + "/" + datetime + "/" + DateTimeTool.GetTimeStamp(DateTime.Now)+ extname;
            model.ThumPic = sys.Value + "/" + datetime + "/" + DateTimeTool.GetTimeStamp(DateTime.Now.AddSeconds(5)) + extname;
            ImageExtension.SaveImage(thumImage, SysBaseHandle.ROOT_DIR + model.ThumPic);
            hf.SaveAs(SysBaseHandle.ROOT_DIR + model.LitPic);
        }

    }
}