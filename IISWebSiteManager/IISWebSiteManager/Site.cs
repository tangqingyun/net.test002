using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISWebSiteManager
{
    public class Site
    {
        /// <summary>
        /// 网站名称
        /// </summary>
        private string siteName;
        public string SiteName
        {
            get { return siteName; }
            set { siteName = value; }
        }
     
        private string port;
        /// <summary>
        /// 端口号
        /// </summary>
        public string Port
        {
            get {
                return string.IsNullOrWhiteSpace(port) ? "*:80:" : string.Format("*:{0}:",port);
            }
            set { port = value; }
        }

        
        private string protocol;
        /// <summary>
        /// 协议
        /// </summary>
        public string Protocol
        {
            get {
                return string.IsNullOrWhiteSpace(protocol) ? "http" : protocol;
                }
            set { protocol = value; }
        }

        private string physicalPath;
        /// <summary>
        /// 网站物理路径
        /// </summary>
        public string PhysicalPath
        {
            get { return physicalPath; }
            set { physicalPath = value; }
        }
    }
}
