using Basement.Framework.Excels;
using Basement.Framework.Net;
using Basement.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CarNumBelongAPI
{
    class Program
    {
        readonly static string URL = "http://www.jihaoba.com/tools/?com=cargsd";
        static void Main(string[] args)
        {
            BatchProcess();
            Console.ReadKey();
            return;
            string text = string.Empty;
            try
            {
                Result result=GetBelongAPI("湘","E");
                text=string.Format("车牌号：{0} | 省份：{1} | 城市：{2} | 区号：{3}", result.CarNum, result.Provice, result.City, result.AreaCode);
            }
            catch (Exception ex)
            {
                text = ex.Message;
            }
            Console.WriteLine(text);
            Console.ReadKey();
        }

        /// <summary>
        /// 获取车牌归属地
        /// </summary>
        /// <param name="p"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        private static Result GetBelongAPI(string p, string city)
        {
            string content = HttpHelper.Get(URL + "&p=" + p + "&city=" + city);
            string parrent = string.Format("<span class=\"hong14\">{0}</span>", @"[\s\S]*?");
            MatchCollection coll = Regex.Matches(content, parrent);
            Result result = null;
            if (coll.Count == 0) 
                return result;

            result = new Result();
            int i = 1;
            foreach (Match itm in coll)
            {
                string newstr = HtmlHelper.RemoveHtml(itm.Value);
                switch (i)
                {
                    case 1:
                        result.CarNum = newstr;
                        break;
                    case 2:
                        string[] arr = newstr.Split(' ');
                        result.Provice = arr[0];
                        result.City =arr.Length==2?arr[1]:"";
                        break;
                    case 3:
                        result.AreaCode = newstr;
                        break;
                    default:
                        break;
                }
                i++;
            }
            return result;
        }

        private static void BatchProcess() {
            Console.WriteLine("处理中.....");
            ExcelExtension excel = new ExcelExtension(@"C:\Users\Administrator\Desktop\车辆违章查询\车牌号01.xls", 0);
            string[] heads = new string[] { "车牌号", "省份", "城市", "区号", "发动机号", "车架号", "车辆类型", "车辆识别码" };
            DataTable dt = excel.ReadExcelAsDataTable(false);
            DataTable newtable = new DataTable();
            newtable.Columns.Add("车牌号");
            newtable.Columns.Add("省份");
            newtable.Columns.Add("城市");
            newtable.Columns.Add("区号");
            newtable.Columns.Add("发动机号");
            newtable.Columns.Add("车架号");
            newtable.Columns.Add("车辆类型");
            newtable.Columns.Add("车辆识别码");
            int i = 1;
            foreach (DataRow dr in dt.Rows)
            {
                if (i == 1)
                {
                    i++;
                    continue;
                }
                //if (i > 10)
                //    break;
                DataRow ndr = newtable.NewRow();
                string jiancheng = dr[0].ToString().Substring(0, 1);
                string carnum = dr[0].ToString().Substring(1, 1);
                Result result = GetBelongAPI(jiancheng, carnum);
                ndr[0] = dr[0];
                ndr[1] = result.Provice;
                ndr[2] = result.City;
                ndr[3] = result.AreaCode;
                ndr[4] = dr[1];
                ndr[5] = dr[2];
                ndr[6] = dr[3];
                ndr[7] = dr[4];
                newtable.Rows.Add(ndr);
                Console.WriteLine((i-1).ToString());
                i++;
            }
            excel.DataTableToExcelFile(newtable, @"C:\Users\Administrator\Desktop\车辆违章查询\车牌号02.xls", heads);
            Console.WriteLine("处理中完成");
        }
        
    }

    public class Result
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNum { set; get; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Provice { set; get; }
        /// <summary>
        /// 城市 
        /// </summary>
        public string City { set; get; }
        /// <summary>
        /// 区号
        /// </summary>
        public string AreaCode { set; get; }
    }

}
