using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uni2uni.com.BLL.OrderSend;

namespace IVRUnitTest
{
    
    public partial class Form1 : Form
    {
        OrderSendService oss = new OrderSendService();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg;
            bool bol = oss.ResendConfirmCodeIVR("",Guid.Empty, out msg);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool bol = false;
            string msg=string.Empty;
            string cardno = this.tbMemberCardNo.Text;
            if (!string.IsNullOrWhiteSpace(cardno))
            {
                string[] arr = cardno.Split(',');
                bol = oss.ResendCardPasswordIVR("51499001936", arr, "15901473139", Guid.Empty, out msg);
            }
            MessageBox.Show(bol.ToString() + msg);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

    }
}
