using Spring.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spring.Service
{
    public class MemberService : IMemberService
    {

        public bool Save(Domain.Member member)
        {
            return true;
        }
    }
}
