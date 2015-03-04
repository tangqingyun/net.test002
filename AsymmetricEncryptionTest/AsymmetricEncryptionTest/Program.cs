using EnterpriseMall.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricEncryptionTest
{
    class Program
    {
        static void Main(string[] args)
        {

            AsymmetricEncryptionUtil.ProtectKey = true;
            string txt = "abc";
           // string asg = AsymmetricEncryptionUtil.GenerateKey(txt);

            byte[] byt = AsymmetricEncryptionUtil.EncryptData(txt, "model");
            Console.Write(byt);

           
            //Console.Write(asg);
            Console.ReadKey();
        }
    }
}
