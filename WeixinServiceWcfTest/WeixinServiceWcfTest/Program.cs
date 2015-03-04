using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeixinServiceWcfTest.WeiXinServiceClient;

namespace WeixinServiceWcfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入卡号多个卡号以逗号隔开！\r\n");
            string txt=Console.ReadLine();
            if (string.IsNullOrWhiteSpace(txt)) {
                Console.Write("请输入卡号多个卡号以逗号隔开！\r\n");
                return;
            }


            string[] arr = txt.Split(',');//8853169000000013
            SecretaryCardSerivceClient client = new SecretaryCardSerivceClient();
            CinemaTicketInfo[] info = client.GetCinemaTicketListByCardNo(arr);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < info.Length; i++)
            {
                CinemaTicketInfo ticket=info[i];
                sb.Append(ticket.CardCode + "电影名：" + ticket.MovieName+"观影时间："+ticket.Screening+ "\r\n");
            }

            if (string.IsNullOrWhiteSpace(sb.ToString())) {
                Console.Write("未获取到电影票信息！");
            }
            Console.Write(sb.ToString());
            Console.ReadKey();
        }
    }
}
