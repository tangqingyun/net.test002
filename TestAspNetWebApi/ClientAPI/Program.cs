using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace ClientAPI
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            client.BaseAddress = new Uri("http://localhost:8080");

            ListAllProducts();

            Console.ReadKey();
        }

        static void ListAllProducts()
        {
            HttpResponseMessage resp = client.GetAsync("api/products").Result;
            resp.EnsureSuccessStatusCode();
            var products = resp.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            foreach (var p in products)
            {
                Console.WriteLine("{0} {1} {2} ({3})", p.Id, p.Name, p.Price, p.Category);
            }

        }


    }
}
