using BTAS.API.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        /// <summary>
        /// Validates the submitted parameters
        /// </summary>
        /// <param name="apikey">Client's APIKEY</param>
        /// <param name="token">Client's requested token from PHP API</param>
        /// <param name="shipperId">Client's provided Shipper Id</param>
        /// <returns></returns>
        public async Task<string> ValidateTokenAsync(string apikey, string token, string shipperId)
        {
            using (var client = new HttpClient())
            {
                var url = "https://api.austwayexpress.com";
                var cl = new HttpClient();
                cl.BaseAddress = new Uri(url);
                int _TimeoutSec = 90;
                cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);
                string _ContentType = "application/json";
                cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
                client.DefaultRequestHeaders.Add("apikey", apikey);
                client.DefaultRequestHeaders.Add("apiToken", token);

                var parameters = new Dictionary<string, string>();
                parameters["apiFunctionName"] = "verifyToken";
                parameters["apiFunctionParams"] = "{ \"shipperId\": \"" + shipperId + "\" }";

                var response = await client.PostAsync(url, new FormUrlEncodedContent(parameters));
                var contents = await response.Content.ReadAsStringAsync();

                return contents;
            }
        }
    }
}
