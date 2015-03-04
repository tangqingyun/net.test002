using Spring.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spring.IService
{
    public interface IMemberService
    {
        public bool Save(Member member)
        {
            return true;
        }

    }
}
