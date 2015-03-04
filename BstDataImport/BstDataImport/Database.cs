using Basement.Framework.Data;
using Basement.Framework.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BstDataImport
{
    public static class Database
    {
        static Database() { }

        public static SqlServer LocalLife_Bst
        {
            get
            {
                return new SqlServer(ConnectionConfig.Connections["Uni2uni_LocalLife_Bst"]);
            }
        }

        public static SqlServer LocalLife_Import
        {
            get
            { 
                return new SqlServer(ConnectionConfig.Connections["Uni2uni_LocalLife_Import"]);
            }
        }

    }
}
