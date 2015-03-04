using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

namespace TextQuartz.Net
{
    [RunInstaller(true)]
    public partial class MyQuartzServiceInstaller : System.Configuration.Install.Installer
    {
        public MyQuartzServiceInstaller()
        {
            InitializeComponent();
        }
    }
}
