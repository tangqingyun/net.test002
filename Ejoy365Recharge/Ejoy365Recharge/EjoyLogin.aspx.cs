using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejoy365Recharge
{
    public partial class EjoyLogin : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {

            IList<ParamKeyValue> postData = new List<ParamKeyValue>() { 
                     new ParamKeyValue("action","Get"),
                     new ParamKeyValue("name","qingyun"),
                     new ParamKeyValue("pwd","123456")
             };

            string url = "http://secure.ejoy365.com/Customer/Login.aspx?ReturnUrl=http%3a%2f%2fsecure.ejoy365.com%2fRecharge%2fRechargeStep1.aspx";
            // string ncontent = HttpHelper.Post(url, list, null, 50 * 1000, null, Encoding.UTF8, null, null);
            CookieCollection hwrCookies;
            string result = HttpHelper.Post(url, postData, "", out  hwrCookies, null, null, Encoding.GetEncoding("gbk"), null, null, null);
            //out CookieCollection cookies,
            Response.Write(result);

        }
    }
}