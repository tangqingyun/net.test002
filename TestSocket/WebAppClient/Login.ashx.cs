using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;

namespace WebAppClient
{
    /// <summary>
    /// Login1 的摘要说明
    /// </summary>
    public class Login1 : IHttpHandler
    {
        HttpRequest Request;
        HttpResponse Response;
        byte[] result = new byte[102400];
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        const int port = 8885;
        public void ProcessRequest(HttpContext context)
        {
            Request = context.Request;
            Response = context.Response;
            string action=Request.Form["action"];
            switch (action)
            {
                case "Login":
                    Login();
                    break;
                case "Go":
                    GoLink();
                    break;
                default:
                    break;
            }

        }
        MemoryStream streams = new MemoryStream();

        private void Login()
        {
            string uname = Request.Form["uname"];
            string upwd = Request.Form["upwd"];
            Socket clientSocket;
            bool  bol=CreateSocketContent(out clientSocket);
            if (!bol)
            {
                return;
            }
            string sendMessage = "do=index&uname=" + uname + "&upwd=" + upwd;
            clientSocket.Send(Encoding.UTF8.GetBytes(sendMessage));
            //int receiveLength = clientSocket.Receive(result);

            int len=clientSocket.Available;
            byte[] buffer = new byte[len];
            clientSocket.Receive(buffer);

            MemoryStream ms = new MemoryStream(buffer);
            ms.WriteTo(streams);
            streams.Position = 0;
            BinaryFormatter b = new BinaryFormatter();
            streams.Seek(0, SeekOrigin.Begin);
            ImageEntity objectTry = (ImageEntity)b.Deserialize(streams);
            
            //MemoryStream mStream = new MemoryStream();
            ////mStream.Position = 0;
            //int ReceiveCount = clientSocket.Receive(buffer);
            //if (ReceiveCount != 0)
            //{
            //    mStream.Write(buffer, 0, ReceiveCount); //将接收到的数据写入内存流
            //}
            //ImageEntity image = (ImageEntity)DeserializeBinary(buffer);
            //mStream.Flush();
            //BinaryFormatter bFormatter = new BinaryFormatter();
            //if (mStream.Capacity > 0)
            //{
            //    ImageEntity image = (ImageEntity)bFormatter.Deserialize(mStream);//将接收到的内存流反序列化为对象
            //    System.IO.MemoryStream ms = new System.IO.MemoryStream(image.ImageByte);
            //    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            //    img.Save(@"C:\Users\Administrator\Desktop\示例项目\TestSocket\WebAppClient\images/" + image.ImageName);
            //    //Console.WriteLine("接收到来自" + msg.sendIP + "的信息内容：" + Encoding.Default.GetString(msg.Data));
            //}
            //else
            //{
            //    //Console.WriteLine("接收到的数据为空。");
            //}
            //clientSocket.Close();
            //Console.WriteLine("线程执行完毕。");           
            //string htmlContent = Encoding.UTF8.GetString(result, 0, receiveLength);
            //clientSocket.Close();
            //Response.Write(htmlContent);
        }

        private void GoLink()
        {
            Socket clientSocket;
            bool bol = CreateSocketContent(out clientSocket);
            if (!bol)
            {
                return;
            }
            clientSocket.Send(Encoding.UTF8.GetBytes("go链接发来的数据"));
            int receiveLength = clientSocket.Receive(result);
            string htmlContent = Encoding.UTF8.GetString(result, 0, receiveLength);
            clientSocket.Close();
            Response.Write(htmlContent);
        }

        /// <summary>
        /// 创建Socket连接
        /// </summary>
        /// <returns></returns>
        public bool CreateSocketContent(out Socket clientSocket)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, port)); //配置服务器IP与端口   
                return true;
            }
            catch
            {
                return false;
            }
        }

        //  二进制反序列化    
        public static object DeserializeBinary(byte[] bobj)
        {
            if (bobj == null || bobj.Length == 0)
                return new object[] { };
            MemoryStream memStream = new MemoryStream(bobj);
            memStream.Position = 0;
            BinaryFormatter de = new BinaryFormatter();
            object newobj = null;
            memStream.Seek(0, SeekOrigin.Begin);
            newobj = de.Deserialize(memStream);
            memStream.Close();
            memStream.Dispose();
            return newobj;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


    }
}