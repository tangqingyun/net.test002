using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtWorks.QRCode.Codec;

namespace BarCode
{
    class Program
    {
        static void Main(string[] args)
        {
            QRCode();
        }

        /// <summary>
        /// 二维码生成 与 内容获取
        /// </summary>
        static void QRCode() {
            Bitmap bitmap = QRCodeUnitl.QRCodeEncoderUtil("http://www.uni2uni.com");//
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "/QRCode.jpg";
            bitmap.Save(fileName);
            Console.WriteLine("二维码生成成功！");
            string content = QRCodeUnitl.QRCodeDecoderUtil(bitmap);
            Console.WriteLine("二维码内容：" + content);
            Console.Read();
        }


    }
}
