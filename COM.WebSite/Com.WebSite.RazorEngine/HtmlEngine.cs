using Basement.Framework.Common;
using Basement.Framework.IO;
using Com.WebSite.Models;
using Com.WebSite.Services;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Com.WebSite.RazorEngine
{
    public class HtmlEngine
    {
        readonly static string temp = SysBaseHandle.ROOT_DIR + @"\template\";
        readonly static string staticDir = SysBaseHandle.ROOT_DIR + @"\yingnuo\";
        public static void CreateArticelHtml(long id)
        {
            string article = File.ReadAllText(temp + "article.cshtml");
            string header = File.ReadAllText(temp + "header.cshtml");
            string mediaflash = File.ReadAllText(temp + "mediaflash.cshtml");
            string footer = File.ReadAllText(temp + "footer.cshtml");
            string leftnav = File.ReadAllText(temp + "leftnav.cshtml");
            Razor.Compile(header, "header.cshtml");
            Razor.Compile(mediaflash, "mediaflash.cshtml");
            Razor.Compile(footer, "footer.cshtml");
            Razor.Compile(leftnav, "leftnav.cshtml");
            IList<Entity_Channel> channeList = InstanceService.GetChannelServiceInstance().GetChannelListByReid(0).ToList();
            string result = Razor.Parse(article, new { ChannelList = channeList });
            FileExtension.WriteText(staticDir + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html", result);
        }

    }
}
