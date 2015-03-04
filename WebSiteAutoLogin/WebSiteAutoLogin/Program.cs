using Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteAutoLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://home.51cto.com/index.php?s=/Index/doLogin";
            IList<ParamKeyValue> list = new List<ParamKeyValue>()
            {                
                new ParamKeyValue("email","tangqingyuncx@qq.com"),
                new ParamKeyValue("passwd","*tangqingyun*"),
                new ParamKeyValue("reback","http%3A%2F%2Fdown.51cto.com"),
                new ParamKeyValue("button.x","40"),
                new ParamKeyValue("button.y","17"),
            };
            CookieCollection cookies = new CookieCollection();
            cookies.Add(new Cookie("pub_cookietime", "0", "/", "51cto.com"));
            cookies.Add(new Cookie("Hm_lvt_f77ea1ecd95cb2a1bc65cbcb3aaba7d4", "1393489784", "/", "51cto.com"));
            cookies.Add(new Cookie("_ourplusFirstTime", "2014-2-24-10-53-50", "/", "home.51cto.com"));
            cookies.Add(new Cookie("_ourplusReturnTime", "2014-2-28-10-18-54", "/", "home.51cto.com"));
            cookies.Add(new Cookie("lzstat_uv", "3172888233270444214|1704230", "/", "51cto.com"));
            cookies.Add(new Cookie("_ourplusReturnCount", "4", "/", "home.51cto.com"));
            cookies.Add(new Cookie("pub_sauth2", "57f45ecd030361987971502121709b4a", "/", "51cto.com"));
            cookies.Add(new Cookie("PHPSESSID", "f80d4f266b4490005b6181fe2924f97a", "/", "home.51cto.com"));
            cookies.Add(new Cookie("pub_sauth1", "FQVXAxQMWQVKQVw4VA9fDQ0LBW1XAQwCV1YCVAZc", "/", "51cto.com"));
            cookies.Add(new Cookie("lastlogin", "on", "/", "home.51cto.com"));

            CookieCollection resCookies;
            string content = HttpHelper.Post(url, list, "", out resCookies, 50 * 1000, null, Encoding.UTF8, null, null, null);
            

            string home = "http://down.51cto.com/";
            string homeHtml = HttpHelper.Get(home, null, null, resCookies, null, null, Encoding.UTF8);


        }
    }
}
