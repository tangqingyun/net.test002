using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;
using System.Web.Http;
namespace TestAspNetWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            int num=Test();
            var config = new HttpSelfHostConfiguration("http://localhost:8080");
            config.Routes.MapHttpRoute("APIDefault", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
            Console.ReadKey();
        }

        public static int Test()
        {
            int i = 1;
            try
            {
                return i;
            }
            finally
            {
                i++;
            }
        }


    }
}
