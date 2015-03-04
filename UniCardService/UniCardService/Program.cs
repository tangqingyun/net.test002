using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uni2uni.UniCard.ClientAPI;
using Uni2uni.UniCard.ClientAPI.Model;

namespace UniCardService
{
    class Program
    {
         
        static void Main(string[] args)
        {

            //UniCard model = CardService.CardLogin("3001010000000032", "321653");
            CardTypeTree tree=CardService.GetCardGroup("3001010000000032");
            int i = 0;
            foreach (var itm in tree.Nodes)
            {
                Console.WriteLine(itm.Group.GroupName);
                foreach (var g in itm.ChildGoods)
                {
                    Console.WriteLine(g.GoodsName);
                }
                i++;
            }
            Console.ReadKey();
        }
    }
}
