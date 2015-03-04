using System.Web;
using System.Web.Mvc;

namespace Uni2Uni.WeiXin.WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}