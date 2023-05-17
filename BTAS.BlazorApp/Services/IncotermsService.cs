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
    public class IncotermsService : BaseService, IIncotermsService
    {
        private readonly IHttpClientFactory _client;
        private IConfiguration config;

        public IncotermsService(IHttpClientFactory client, IConfiguration config) : base(client)
        {
            _client = client;
            this.config = config;
        }

        public async Task<T> GetAllIncotermsAsync<T>()
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.IncotermsApiBase + "?web=true",
                AccessToken = config["Credentials:AccessToken"],
                AccessKey = config["Credentials:AccessKey"],
                ShipperId = config["Credentials:ShipperId"],
                web = "true"
            });

            return result;
        }
    }
}
