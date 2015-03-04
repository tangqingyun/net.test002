using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace TestSocket
{
    class Program
    {
        private static byte[] result = new byte[1024];
        private static int myProt = 8885;   //端口   
        static Socket serverSocket;
        static void Main(string[] args)
        {
            //服务器IP地址   
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, myProt));  //绑定IP地址：端口   
            serverSocket.Listen(1000);    //设定最多1000个排队连接请求   
            Console.WriteLine("启动监听{0}成功", serverSocket.LocalEndPoint.ToString());
            //通过Clientsoket发送数据   
            Thread myThread = new Thread(ListenClientConnect);
            myThread.Start();
            Console.ReadLine();
        }

        /// <summary>   
        /// 监听客户端连接   
        /// </summary>   
        private static void ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(clientSocket);
            }
        }

        /// <summary>   
        /// 接收消息   
        /// </summary>   
        /// <param name="clientSocket"></param>   
        private static void ReceiveMessage(object clientSocket)
        {
            Socket myClientSocket = (Socket)clientSocket;
            while (true)
            {
                try
                {
                    //通过clientSocket接收数据   
                    int receiveNumber = myClientSocket.Receive(result);
                    string clientData = Encoding.UTF8.GetString(result, 0, receiveNumber);
                    if (clientData.IndexOf("index") > -1)
                    {
                        Console.WriteLine("接收客户端{0}消息{1}", myClientSocket.RemoteEndPoint.ToString(), clientData);
                        //StringBuilder sb = new StringBuilder();
                        //StreamReader srReadFile = new StreamReader(@"C:\Users\Administrator\Desktop\示例项目\TestSocket\TestSocket\template\index.html");
                        //while (!srReadFile.EndOfStream)
                        //{
                        //    sb.Append(srReadFile.ReadLine());
                        //}
                        string imagePath = @"C:\Users\Administrator\Desktop\示例项目\TestSocket\TestSocket\css\ad.jpg";
                        ImageEntity img = ReadImageDataByte(imagePath);
                        //myClientSocket.Send(Encoding.UTF8.GetBytes(sb.ToString()));
                        myClientSocket.Send(Serialize.serialize(img));
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    myClientSocket.Shutdown(SocketShutdown.Both);
                    myClientSocket.Close();
                    break;
                }
            }
        }

        private static ImageEntity ReadImageDataByte(string imagesPath)
        {
            //= @"C:\Users\Administrator\Desktop\示例项目\TestSocket\TestSocket\css\ad.jpg";
            FileStream fs = new FileStream(imagesPath, FileMode.Open);
            byte[] byData = new byte[fs.Length];
            fs.Read(byData, 0, byData.Length);
            var img = new ImageEntity
            {
                ImageByte = byData,
                Size = byData.Length,
                ImageName = Path.GetFileName(imagesPath)
            };
            fs.Close();
            return img;
        }

    }


    [Serializable]
    public class ImageEntity
    {
        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImageName { set; get; }
        /// <summary>
        /// 图片二进制数据
        /// </summary>
        public byte[] ImageByte { set; get; }
        /// <summary>
        /// 图片大小
        /// </summary>
        public int Size { set; get; }
    }

    /// <summary>
    /// 序列化对象类
    /// </summary>
    public class Serialize
    {
        public static byte[] serialize(object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            formatter.Serialize(ms, obj);
            byte[] tmp = ms.ToArray();
            ms.Close();
            return tmp;
        }
    }

}
