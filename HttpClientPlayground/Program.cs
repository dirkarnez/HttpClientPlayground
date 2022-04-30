using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientPlayground
{
    class Program
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            Console.WriteLine(GetSomeString("1").Result);
            Console.ReadLine();
        }

        static async Task<string> GetSomeString(string placeholder)
        {
            try
            {
                return await client.GetStringAsync($"https://jsonplaceholder.typicode.com/todos/{placeholder}");
            }
            catch (HttpRequestException)
            {
                return string.Empty;
            }
        }
    }
}
