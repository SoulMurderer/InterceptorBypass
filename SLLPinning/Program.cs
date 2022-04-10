using System;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;


namespace SLLPinning
{
    class Program
    {
        static void Main(string[] args)
        {
			//HttpWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://google.com/");
            request.Proxy = new WebProxy();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.ResponseUri);




			//HttpClient
            var proxy = new WebProxy();

            var httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy,
            };



            var client = new HttpClient(handler: httpClientHandler, disposeHandler: true);



            var result = client.GetAsync("http://google.com/").GetAwaiter().GetResult();
            Console.WriteLine(result);






        }

    }
}
