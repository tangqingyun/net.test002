using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace VirtualAccount.Controller
{
    public class DemoController : ApiController
    {
        // GET api/Demo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
