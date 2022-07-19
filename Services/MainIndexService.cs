using Cryptocurrency_Helper.Interfaces;
using Cryptocurrency_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Cryptocurrency_Helper.Services
{

    public static class MainIndexService
    {
        public static async Task<MainAssetStorage> GetMainIndex()
        {
            string url = "https://api.coincap.io/v2/assets";
            //string url = "https://api.coingecko.com/api/v3/indexes/";

            using (HttpResponseMessage response = await ServiceApi.Client.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    var JsonResponse = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject<ObservableCollection<MainIndex>>(JsonResponse);                   
                    var result = JsonConvert.DeserializeObject<MainAssetStorage>(JsonResponse);                    
                    return result;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            
        }
             

        //public async Task<List<MainIndex>> GetMainIndex()
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        HttpResponseMessage response = await client.GetAsync("https://api.coingecko.com/api/v3/indexes");
        //        string JsonResponse = await response.Content.ReadAsStringAsync();                
        //        var result = JsonConvert.DeserializeObject<List<MainIndex>>(JsonResponse);
        //        return result;
        //    }
        //}
    }
}
