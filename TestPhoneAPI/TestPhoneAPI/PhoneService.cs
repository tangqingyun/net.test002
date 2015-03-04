using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace uni2uni.com.BLL.Common.Controls
{
    /// <summary>
    /// 电话归属地查询服务
    /// </summary>
    public class PhoneService
    {
        /// <summary>
        ///  从360网站获取电话归属地信息 
        /// </summary>
        /// <param name="telNumber">号码</param>
        /// <returns></returns>
        public TelePhoneData GetPhoneInfoFrom360(string phone)
        {
            string address = "http://cx.shouji.360.cn/phonearea.php?number=" + phone;
            string content = SendGet(address);
            //{"code":0,"data":{"province":"\u6e56\u5357","city":"\u90b5\u9633","sp":"\u79fb\u52a8"}}
            string status = content.Substring(content.IndexOf(":") + 1, 1);
            if (status != "0") //如果返回的状态码不为0说明没有获取到 归属地信息
            {
                return null;
            }
            string pattern = @"""[\s\S]*?""";
            MatchCollection mc = Regex.Matches(content, pattern, RegexOptions.IgnoreCase);
            if (mc.Count == 0)
            {
                return null;
            }
            TelePhoneData phoneInfo = new TelePhoneData
            {
                Province = !string.IsNullOrWhiteSpace(mc[3].Value) ? mc[3].Value.Replace("\"", "") : "",
                City = !string.IsNullOrWhiteSpace(mc[5].Value) ? mc[5].Value.Replace("\"", "") : "",
                Town = "",
                Provider = !string.IsNullOrWhiteSpace(mc[7].Value) ? mc[7].Value.Replace("\"", "") : "",
                TelePhone = phone
            };
            return phoneInfo;
        }

        /// <summary>
        /// 检测是否是北京手机
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public bool HasBeiJingPhone(string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile))
            {
                return false;
            }
            TelePhoneData phone=GetPhoneInfoFrom360(mobile);
            if (!string.IsNullOrWhiteSpace(phone.Province))
            {
                string province=UnicodeToChina(phone.Province);
                if (province.Contains("北京") || province.Contains("北京市"))
                {
                    return true;
                }
            }
            else if (!string.IsNullOrWhiteSpace(phone.City))
            {
                string city = UnicodeToChina(phone.City);
                if (city.Contains("北京") || city.Contains("北京市"))
                {
                    return true;
                }
            }
            return false;
        }

        private string SendGet(string address)
        {
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "GET";
            HttpWebResponse respone = request.GetResponse() as HttpWebResponse;
            Stream stream = respone.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("gb2312"));
            return reader.ReadToEnd();
        }

        /// <summary>
        /// 将Unicode转换成汉字
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private string UnicodeToChina(string source)
        { 
            System.Text.RegularExpressions.MatchCollection mc = System.Text.RegularExpressions.Regex.Matches(source, "\\\\u([\\w]{4})");
            if (mc != null && mc.Count > 0)
            {
                foreach (System.Text.RegularExpressions.Match m2 in mc)
                {
                    string v = m2.Value;
                    string word = v.Substring(2);
                    byte[] codes = new byte[2];
                    int code = Convert.ToInt32(word.Substring(0, 2), 16);
                    int code2 = Convert.ToInt32(word.Substring(2), 16);
                    codes[0] = (byte)code2;
                    codes[1] = (byte)code;
                    source = source.Replace(v, Encoding.Unicode.GetString(codes));
                }
            }
            return source;
        }

    }

    public class TelePhoneData
    {
        /// <summary>
        /// 所属省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 所属市
        /// </summary>
        public string City { set; get; }
        /// <summary>
        /// 所属区/镇
        /// </summary>
        public string Town { set; get; }
        /// <summary>
        /// 号码
        /// </summary>
        public string TelePhone { get; set; }
        /// <summary>
        /// 服务提供商
        /// </summary>
        public string Provider { get; set; }

    }

}
