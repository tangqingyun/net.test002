using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.WebSite.Models.ParamterEntity
{
    [Serializable]
    public class ArticleQueryParam
    {
        public int ChannelID { set; get; }
        public string Title { set; get; }
    }
}
