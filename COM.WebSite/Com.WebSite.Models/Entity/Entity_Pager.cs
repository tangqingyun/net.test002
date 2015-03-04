using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.WebSite.Models.Entity
{
    public class Entity_Pager
    {
        public int Index { set; get; }
        public int Size { set; get; }
        public int Total { set; get; }
        public int PageCount
        {
            get
            {
                //计算共有多少页        
                if (Total % Size == 0)
                {
                    return Total / Size;
                }
                else
                {
                    return  Total / Size + 1;
                }
            }
        }
    }
}
