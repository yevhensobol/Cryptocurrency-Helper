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

            using (HttpResponseMessage response = await ServiceApi.Client.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    var JsonResponse = await response.Content.ReadAsStringAsync();                 
                    var result = JsonConvert.DeserializeObject<MainAssetStorage>(JsonResponse);                    
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            
        }     

    }
}
