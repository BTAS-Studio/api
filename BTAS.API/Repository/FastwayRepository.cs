using AutoMapper;
using BTAS.API.Areas.Carriers.Models.Apg;
using BTAS.API.Areas.Carriers.Models.Fastway;
using BTAS.API.Models;
using BTAS.Data;
using BTAS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class FastwayRepository
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        IConfiguration config;
        private string token;
        IHttpClientFactory _clientFactory;

        public FastwayRepository(MainDbContext context, IMapper mapper, IConfiguration config, IHttpClientFactory clientFactory)
        {
            _context = context;
            _mapper = mapper;
            this.config = config;
            _clientFactory = clientFactory;
        }

        private class tokenRequestParameter
        {
            public string grant_type { get; set; }
            public string scope { get; set; }
            public string token_name { get; set; }
            public string client_id { get; set; }
            public string client_secret { get; set; }
        }

        private class tokenResponse
        {
            public string access_token { get; set; }
        }

        private async Task GetToken()
        {
            string url = "https://identity.fastway.org";

            List<tokenRequestParameter> tokenParam = new();

            tokenParam.Add(new tokenRequestParameter
            {
                //token_name = "Vina Enterprise Pty Ltd",
                grant_type = "client_credentials",
                scope = "fw-fl2-api-au",
                client_id = "fw-fl2-SYD9070112-87eeb61fb25d",
                client_secret = "8bcc023c-03e0-4695-8141-1bbe66d4c299"
            });



            HttpClient client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(url);

            var content = new StringContent($"grant_type=client_credentials&client_id=fw-fl2-SYD9070112-87eeb61fb25d&scope=fw-fl2-api-au&client_secret=8bcc023c-03e0-4695-8141-1bbe66d4c299");
            
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var response = await client.PostAsync($"https://identity.fastway.org/connect/token", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<tokenResponse>(result).access_token.Replace($"\"", ""); //["access_token"].ToString();
            }

        }

        public async Task<FWCreateShippingResponse> CreateShipmentAsync(FWCreateShippingRequest request)
        {
            try
            {
                await GetToken();

                HttpClient client = _clientFactory.CreateClient();

                var content = new StringContent(JsonConvert.SerializeObject(request),Encoding.UTF8,"application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                content.Headers.Add("api-version", "1.0");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.PostAsync($"https://api.myfastway.com.au/api/consignments", content);

                var resultString = await response.Content.ReadAsStringAsync();
                
                var result = JsonConvert.DeserializeObject<FWCreateShippingResponse>(resultString);

                if(result.data != null)
                {
                    var label = await CreateLabelAsync(result.data.conId.ToString(), "4x6");
                    result.label = label;
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<string> CreateLabelAsync(string consignment, string pageSize)
        {
            try
            {
                //token = JsonConvert.SerializeObject(await GetToken());

                HttpClient client = _clientFactory.CreateClient();

                //client.DefaultRequestHeaders.Add("content-type", "application/pdf");
                client.DefaultRequestHeaders.Add("api-version", "1.0");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string endpoint = "/api/consignments/" + consignment + "/labels/?pageSize=" + pageSize;
                var response = await client.GetAsync($"https://api.myfastway.com.au/api/consignments/" + consignment + "/labels/?pageSize=" + pageSize);

                MemoryStream ms = new MemoryStream(await response.Content.ReadAsByteArrayAsync());
                return Convert.ToBase64String(ms.ToArray());
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
