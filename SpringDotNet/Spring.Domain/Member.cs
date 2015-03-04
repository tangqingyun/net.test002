using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spring.Domain
{
    public class Member
    {
        public Guid MemberID { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }
    }
}
