using System;
using System.Net;

namespace WebApiClient
{
    class Program
    {
        private const string Uri = "http://localhost:8080/api/Cache";

        static void Main(string[] args)
        {
            using (var wc = new WebClient())
            {
                GetRequest();
                PostRequest();
            }

            Console.WriteLine("Type g - for Get request, p - for Post request, e - for exit.");

            var input = string.Empty;
            while (input != "e")
            {
                input = Console.ReadLine();
                if (input == "g")
                    GetRequest();
                if(input == "p")
                    PostRequest();
            }
        }

        private static void GetRequest()
        {
            using (var wc = new WebClient())
            {
                Console.Write("Run GET request... ");
                var response = wc.DownloadString(Uri);
                Console.WriteLine("Response:" + response);
            }
        }

        private static void PostRequest()
        {
            using (var wc = new WebClient())
            {
                Console.WriteLine("Run POST request. Reset cache");
                wc.UploadString(Uri, string.Empty);
            }
        }
    }
}
