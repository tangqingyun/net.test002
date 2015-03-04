using Common.Logging;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace TextQuartz.Net
{
    public  partial class MyQuartzService : ServiceBase
    {
        // ILog log = LogManager.GetLogger(typeof(MyQuartzService));
        IScheduler sched = null;
        public MyQuartzService()
        {
            InitializeComponent();
            this.ServiceName = "MyQuartzService";
            ISchedulerFactory factory = new StdSchedulerFactory();
            sched = factory.GetScheduler();
        }

        protected override void OnStart(string[] args)
        {
            sched.Start();
            //log.Info("------- 服务启动 --------");
        }

        protected override void OnStop()
        {
            sched.Shutdown();
           // log.Info("------- 服务停止 --------");
        }

    }
}
