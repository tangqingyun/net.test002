using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCinemaClubAPI.CinemaClubService;

namespace TestCinemaClubAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            CinemaClubService.SecretaryCardSerivceClient client = new SecretaryCardSerivceClient();
            CinemaCardInfo card = client.GetCinemaClubCard("8853169000000002", "225782");
            Console.WriteLine("卡号："+card.CardCode+"状态："+card.Status+"手机号："+card.Mobile);
            Console.ReadKey();
          
        }

     
    }
}
