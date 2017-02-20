using System;
using System.Net;

namespace WebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {            
            string uri = "http://localhost:8080/api/Cache";

            using (var wc = new WebClient())
            {
                Console.WriteLine("Run GET request...");
                var temp = wc.DownloadString(uri);
                Console.WriteLine(temp);

                Console.WriteLine("Run POST request. Reset cache");
                wc.UploadString(uri,string.Empty);

                Console.WriteLine("Run GET request...");
                temp = wc.DownloadString(uri);
                Console.WriteLine(temp);
            }



            Console.ReadLine();
        }
    }
}
