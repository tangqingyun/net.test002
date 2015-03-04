using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestInternetCookie
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string key = "name";
            string value = "zhangsan";
            string path = "/";
            string cookievalue = value + ";" + path + ";expires=Sun,22-Feb-2015 00:00:00 GMT";
            Common.IECookieHelper.SetInternetCookie("http://secure.ejoy365.com", key, cookievalue);
        }
    }
}