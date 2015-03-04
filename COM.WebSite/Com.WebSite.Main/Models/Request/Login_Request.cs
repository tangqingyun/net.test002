using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.WebSite.Main.Models.Request
{

    public class Login_Request
    {
        public string Name { set; get; }
        public string Pwd { set; get; }
        public string RndCode { set; get; }
    }
}