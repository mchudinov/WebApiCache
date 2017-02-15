using System;
using Microsoft.Owin.Hosting;

namespace WebApiCache
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:8080"))
            {
                Console.WriteLine("API is listening at http://localhost:8080/api/");
                Console.ReadLine();
            }
        }
    }
}
