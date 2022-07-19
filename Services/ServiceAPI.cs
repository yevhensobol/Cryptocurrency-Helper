using Cryptocurrency_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Cryptocurrency_Helper.Services
{
    public static class ServiceApi
    {
        public static HttpClient Client { get; private set; }

        public static void InitializeClient()
        {
            Client = new HttpClient();
            //Client.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));            
        }
    }
}
