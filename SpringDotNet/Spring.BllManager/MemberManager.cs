using Spring.Domain;
using Spring.IService;
using Spring.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spring.BllManager
{
    public class MemberManager
    {
        IMemberService memberBll;
        public MemberManager()
        {
            memberBll = new MemberService();
        }

        public bool Save(Member member)
        {
            return memberBll.Save(member);
        }

    }
}
