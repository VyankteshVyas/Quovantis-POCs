using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using RestSharp;
using Newtonsoft.Json;


namespace Http_basics
{
    class Program
    {
        static void Main(string[] args)
        {
            GetRequest();
            Console.WriteLine("Oye hoye");
            Console.ReadLine();
        }




        //async static void GetReqest(string url)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //       using (HttpResponseMessage response = await client.GetAsync(url))
        //        {
        //            using(HttpContent content = response.Content)
        //            {
        //                string mystr=await content.ReadAsStringAsync();
        //                HttpContentHeaders myheaders = content.Headers;

        //                Console.WriteLine(myheaders);
        //            }

        //        }

        //    }
        //}

        async static  void GetRequest()
        {
            var client = new HttpClient();
            var content = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/1");

            Console.WriteLine(content);

        }

        async static void PostRequest()
        {
            var mypost = new Rootobject();
            mypost.body = "Vyanktesh has created this body";
            mypost.title = "vyanktesh post";
            mypost.userId = 679;
            var jsoncont=JsonConvert.SerializeObject(mypost);
            var data = new StringContent(jsoncont, Encoding.UTF8, "application/json");
            var myurl = "https://jsonplaceholder.typicode.com/posts";
            var client = new HttpClient();
            var response = await client.PostAsync(myurl, data);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            
        }

        async static void PutRequest()
        {
            var mypost = new PutObject();
            mypost.body = "Vyanktesh has created this body";
            mypost.title = "vyanktesh post";
            mypost.userId = 679;
            mypost.id = 1;
            var jsoncont = JsonConvert.SerializeObject(mypost);
            var data = new StringContent(jsoncont, Encoding.UTF8, "application/json");
            var myurl = "https://jsonplaceholder.typicode.com/posts/1";
            var client = new HttpClient();
            var response = await client.PutAsync(myurl, data);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);

        }

        async static void DeleteRequest()
        {
            
            var myurl = "https://jsonplaceholder.typicode.com/posts/1";
            var client = new HttpClient();
            var response = await client.DeleteAsync(myurl);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);

        }
    }

    public class Rootobject
    {
        
        public int userId { get; set; }
        
        public string title { get; set; }
        public string body { get; set; }
    }

    public class PutObject
    {
        public int id { get; set; }
        public int userId { get; set; }

        public string title { get; set; }
        public string body { get; set; }
    }
}
