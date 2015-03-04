using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TextQuartz.Net
{
    public class HelloWorldJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            String path = AppDomain.CurrentDomain.BaseDirectory + "Job\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.AppendAllText(path + "job.txt", DateTime.Now.ToString() + "\n");
        }

    }
}
