using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Cryptocurrency_Helper.Models;

namespace Cryptocurrency_Helper.Services
{
    public static class GetTop10Service
    {
        public static async Task<MainAssetStorage> GetTop10()
        {
            string url = "https://api.coincap.io/v2/assets/?limit=10";

            using (HttpResponseMessage response = await ServiceApi.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
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
