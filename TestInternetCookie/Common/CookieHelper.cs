using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace Common
{
    public static class IECookieHelper
    {
        /// <summary>
        /// 通过COM来获取Cookie数据。 
        /// </summary>
        /// <param name="url">当前网址。</param>
        /// <param name="cookieName">CookieName.</param>
        /// <param name="cookieData">用于保存Cookie Data的实例。</param>
        /// <param name="size">Cookie大小。</param>
        /// <returns>如果成功则返回true,否则返回false。</returns>
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetGetCookie(string url, string cookieName, StringBuilder cookieData, ref int size);

        /// <summary>
        /// 获取当前的实例。
        /// </summary>
        /// <param name="uri">当前地址。</param>
        /// <returns>当前的实例。</returns>
        public static CookieContainer GetInternetCookie(Uri uri)
        {
            CookieContainer cookies = null;
            // 定义Cookie数据的大小。
            int datasize = 20480;
            StringBuilder cookieData = new StringBuilder(datasize);

            if (!InternetGetCookie(uri.ToString(), null, cookieData,
              ref datasize))
            {
                if (datasize < 0)
                    return null;

                // 确信有足够大的空间来容纳Cookie数据。
                cookieData = new StringBuilder(datasize);
                if (!InternetGetCookie(uri.ToString(), null, cookieData,
                  ref datasize))
                    return null;
            }


            if (cookieData.Length > 0)
            {
                cookies = new CookieContainer();
                cookies.SetCookies(uri, cookieData.ToString().Replace(';', ','));
            }
            return cookies;
        }

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);

        /// <summary>
        /// 设置cookie
        /// </summary>
        /// <param name="url">域名</param>
        /// <param name="cookieName">cookie名称</param>
        /// <param name="cookieData">cookie值</param>
        /// <returns></returns>
        public static bool SetInternetCookie(string url, string cookieName, string cookieValue)
        {
            return InternetSetCookie(url, cookieName, cookieValue);
        }

    }
}
