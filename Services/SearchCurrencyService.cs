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
    public static class SearchCurrencyService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Name (id) of the cryptocurrency</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<SearchData> SearhByName(string id)
        {
            string url = "https://api.coincap.io/v2/assets/" + id.ToLower();

            using (HttpResponseMessage response = await ServiceApi.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var JsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<SearchData>(JsonResponse);
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
