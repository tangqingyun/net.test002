using Basement.Framework.Common;
using Basement.Framework.IO;
using Com.WebSite.Main.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace Com.WebSite.Main.Ashx
{
    /// <summary>
    /// FolderManage 的摘要说明
    /// </summary>
    public class FolderManage : BaseHandler
    {

        HttpRequest Request;
        HttpResponse Response;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            Request = context.Request;
            Response = context.Response;
            var action = Request.Form["action"];
            string result = " ";
            switch (action)
            {
                case "LoadFile":
                    result = LoadFolderFiles();
                    break;
                default:
                    break;
            }
            Response.Write(result);
        }

        public string LoadFolderFiles()
        {
            FileInfo[] files = FolderExtension.GetDirectoryFiles(SysBaseHandle.ROOT_DIR, "*.aspx");
            List<object> list = new List<object>();
            if (files.Length > 0)
            {
                files.ToList().ForEach(m =>
                {
                    list.Add(new { FileName = m.Name.ToLower(), FilePath ="/"+m.Name.ToLower() });
                });
            }
            return new JavaScriptSerializer().Serialize(list);
        }

        public override bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class ResultFile
    {
        public string FileName { set; get; }
        public string FilePath { set; get; }
    }

}