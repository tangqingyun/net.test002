using MSSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClubSeriesData
{
    public partial class Form1 : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Uni2uni_GoodsInfo"].ToString();
        DatabaseHelper db ;
        public Form1()
        {
            InitializeComponent();

            
            db = new DatabaseHelper(conn);

            //GetGoods();
        }

        

    }
}
