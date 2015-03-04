using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextQuartz.Net;
using Topshelf;

namespace TextQuartz.Topshelf
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<MyQuartzService>((s) =>
                {
                    s.SetServiceName("ser");
                    s.ConstructUsing(name => new MyQuartzService());
                    //s.WhenStarted((t) => t.());
                    s.WhenStopped((t) => t.Stop());
                });

                x.RunAsLocalSystem();

                //服务的描述
                x.SetDescription("Topshelf_Description");
                //服务的显示名称
                x.SetDisplayName("Topshelf_DisplayName");
                //服务名称
                x.SetServiceName("Topshelf_ServiceName");

            });

        }
    }
}
