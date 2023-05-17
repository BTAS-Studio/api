using BTAS.BlazorApp;
using BTAS.BlazorApp.Models;
using BTAS.BlazorApp.Models.Dto;
using BTAS.BlazorApp.Services;
using BTAS.BlazorApp.Services.Interface;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Services
{
    public class MawbService : BaseService, IMawbService
    {
        private readonly IHttpClientFactory _client;
        private IConfiguration config;

        public MawbService(IHttpClientFactory client, IConfiguration config) : base(client)
        {
            _client = client;
            this.config = config;
        }

        public async Task<T> GetMawbByReferenceAsync<T>(string reference)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.MawbApiBase + "/getbyreference?referenceNumber=" + reference,
                AccessToken = config["Credentials:AccessToken"],
                AccessKey = config["Credentials:AccessKey"],
                ShipperId = config["Credentials:ShipperId"],
                web = "true"
            });
            return result;
        }

        public async Task<T> GetAllAsync<T>()
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.MawbApiBase + "?web=true",
                AccessToken = config["Credentials:AccessToken"],
                AccessKey = config["Credentials:AccessKey"],
                ShipperId = config["Credentials:ShipperId"],
                web = "true"
            });

            return result;
        }

        public async Task<T> GetAllAsync<T>(SearchFilter filter)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.MawbApiBase + "/getfiltered?web=true",
                AccessToken = config["Credentials:AccessToken"],
                AccessKey = config["Credentials:AccessKey"],
                ShipperId = config["Credentials:ShipperId"],
                web = "true",
                Data = filter
            });
            
            return result;
        }
    }
}
