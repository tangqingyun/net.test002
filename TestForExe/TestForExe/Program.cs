using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace TestForExe
{
    class Program
    {
        static void Main(string[] args)
        {

            Process process = new System.Diagnostics.Process();
            Process[] processes = Process.GetProcessesByName("TestHttpRequestLog.exe");
            Process pros = CheckProcess("TestHttpRequestLog");
            if (pros == null)
            {
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.FileName = @"C:\Users\Administrator\Desktop\示例项目\TestHttpRequestLog\TestHttpRequestLog\bin\Debug\TestHttpRequestLog.exe"; //"输入完整的路径" 
                process.StartInfo.Arguments = "QQ.exe"; //启动参数    
                process.Start();
            }
            else {
                pros.StartInfo.Arguments = "dddddddddd";
            }

            Console.ReadKey();
        }


        public static Process CheckProcess(string appname)
        {
            Process[] processList = System.Diagnostics.Process.GetProcesses();
            Process isz = null;
            foreach (Process p in processList)
            {
                if (p.ProcessName == appname)
                {
                    isz = p;
                }
            }
            return isz;
        }
    }
}
