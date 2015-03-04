using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Uni2uni.Framework.Logging;
using Uni2uni.Framework.Redis;


namespace EnterpriseMall.WebAPI.Filter
{
    /// <summary>   
    /// 基本验证Attribtue，用以WebApi请求的权限处理   
    /// </summary>   
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {
        private static Uni2uni.Framework.Cache.ICache cache = CacheFactory.Redis(RedisDb.User);

        /// <summary>   
        /// 检查用户是否有该WebApi请求执行的权限   
        /// </summary>   
        /// <param name="actionContext"></param>   
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Contains("Set-Cookie"))
            {
                var accessToken = actionContext.Request.Headers.GetValues("Set-Cookie");
                Dictionary<string, string> item = new Dictionary<string, string>();
                accessToken.FirstOrDefault().ToString().Split('&').Each(i =>
                {
                    var itemLine = i.Split('=');
                    item.Add(itemLine[0], itemLine[1]);
                });
                //解密用户token值，看有没有登录
                string tokenValue = System.Web.HttpUtility.UrlDecode(item["access_token"]);
                if (ValidateToken(tokenValue))
                {
                    base.OnActionExecuting(actionContext);
                }
                else
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    actionContext.Response.Content = new StringContent("The request has no token or toke id expired,is invalid !",
                                                          Encoding.UTF8, "text/plain");
                }
            }
            else
            {
                //检查web.config配置是否要求权限校验   
                bool isRquired = (WebConfigurationManager.AppSettings["WebApiAuthenticatedFlag"].ToString() == "true");
                if (isRquired)
                {
                    //如果请求Header不包含token，则判断是否是匿名调用   
                    var attr = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                    bool isAnonymous = attr.Any(a => a is AllowAnonymousAttribute);

                    //是匿名用户，则继续执行；非匿名用户，抛出“未授权访问”信息   
                    if (isAnonymous)
                    {
                        base.OnActionExecuting(actionContext);
                    }
                    else
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        actionContext.Response.Content = new StringContent("The request is Unauthorized,is nto allow!",
                                                        Encoding.UTF8, "text/plain");
                    }
                }
                else
                {
                    base.OnActionExecuting(actionContext);
                }
            }
        }

        /// <summary>
        /// 验证是否登录授权
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool ValidateToken(string token)
        {
            //if (!string.IsNullOrEmpty(token))
            //{
            //    var model = cache.Get<LoginMember>(token);
            //    Logger.Error("2:请求中的。。。:model:" + model == null ? "不存在" : model.UserName);
            //    return model != null ? true : false;
            //}
            return false;
        }
    }
}