using Basement.Framework.Utility;
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
    public partial class FriendLink_Edit : EBasePage<FriendLink_Edit>
    {
        private readonly FriendLinkService _FriendLinkService = InstanceService.GetInstance<FriendLinkService>();
        protected Entity_FriendLink model = new Entity_FriendLink();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Save();
            }
            else {
                InitPageData();
            }
        }

        private void InitPageData() {
            int id;
            int.TryParse(GetQueryString("id"), out id);
            if (id > 0) {
                model = _FriendLinkService.GetFriendLinkByID(id);
            }
        }

        private void Save()
        {

         
            Entity_FriendLink model = base.RequestAsModel<Entity_FriendLink>();
            if (!ModelState.IsValid)
            {
                var values = ModelState.Errors.FirstOrDefault();
                ClientScriptAlert(values.ErrorMessage);
                return;
            }
            model.CreateBy = LoginUser.ID;
            model.UpdateBy = LoginUser.ID;

            bool b = false;
            string msg = string.Empty;
            try
            {
                HttpPostedFile hf = Request.Files["logoimg"];
                if (hf != null && hf.ContentLength != 0)
                {
                    SiteConfig config = new SiteConfig();
                    Entity_SysInfo upload = config["cfg_medias_dir"];
                    string extname = Path.GetExtension(hf.FileName);
                    string dirPath = MapPath(upload.Value + "/FriendLink/");
                    if (!Directory.Exists(dirPath)) {
                        Directory.CreateDirectory(dirPath);
                    }
                    string fileName=DateTimeTool.GetTimeStamp(DateTime.Now) + extname;
                    string file = dirPath + fileName;
                    model.Logo = upload.Value + "/FriendLink/" + fileName;
                    hf.SaveAs(file);
                }
                if (model.ID == 0)
                {
                    b = _FriendLinkService.AddFriendLink(model);
                }
                else {
                    b = _FriendLinkService.UpdateFriendLink(model);
                }
            }
            catch (Exception ex)
            {
                AlertMessage(ex.Message.Replace("\"",""));
                return;
            }
            AlertMessage(b ? "保存成功" : "保存失败");
        }
    }
}