using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using uni2uni.com.BLL.Common.Controls;

namespace TestPhoneAPI
{
    public partial class Main : Form
    {
        string mobilestr = @"";
        public Main()
        {
            InitializeComponent();
        }

        PhoneService ps = new PhoneService();
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string mobile = this.tbPhone.Text.Trim();
            if (string.IsNullOrWhiteSpace(mobile))
            {
                MessageBox.Show("电话不能为空！");
                return;
            }
            try
            {
                bool bol = ps.HasBeiJingPhone(mobile);
                TelePhoneData data = ps.GetPhoneInfoFrom360(mobile);
                tbContent.Text = "省份：" + UnicodeToChina(data.Province) + "\r\n城市：" + UnicodeToChina(data.City) + "\r\n城镇：" + data.Town + "\r\n供应商：" + UnicodeToChina(data.Provider) + "\r\n归属北京：" + bol.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
           
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

        private void BatchMobile() {
            string[] arr = mobilestr.Split(',');
            XDocument document = new XDocument();
            XElement contacts = new XElement("root");
            for (int i = 0; i < arr.Length; i++)
            {
                TelePhoneData data = ps.GetPhoneInfoFrom360(arr[i].Replace("\r\n",""));
                if (data == null)
                    continue;
                XElement item = new XElement("option", UnicodeToChina(data.Province) + "|" + UnicodeToChina(data.City) + "|" + data.TelePhone);
                contacts.Add(item);
            }
            document.Add(contacts);          
            document.Declaration = new XDeclaration("1.0", "utf-8", "true");
            document.Save(@"C:\Users\Administrator\Desktop\示例项目\TestPhoneAPI\TestPhoneAPI\text.xml");     
        }

    }
}
