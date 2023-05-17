using BTAS.BlazorApp;
using BTAS.BlazorApp.Extensions;
using BTAS.BlazorApp.Models;
using BTAS.BlazorApp.Models.Dto;
using BTAS.BlazorApp.Services;
using BTAS.BlazorApp.Services.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Services
{
    public class ClientHeaderService : BaseService, IClientHeaderService
    {
        private readonly IHttpClientFactory _client;
        private IConfiguration config;

        public ClientHeaderService(IHttpClientFactory client, IConfiguration config) : base(client)
        {
            _client = client;
            this.config = config;
        }

        public async Task<T> CreateClientHeaderAsync<T>(tbl_client_headerDto entity)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = entity,
                Url = SD.AddressBookApiBase + "/create",
                AccessToken = config["Credentials:AccessToken"],
                AccessKey = config["Credentials:AccessKey"],
                ShipperId = config["Credentials:ShipperId"]
            });

            return result;
        }

        public Task<T> DeleteClientHeaderAsync<T>(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> GetAllClientHeadersAsync<T>()
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AddressBookApiBase + "?web=true",
                AccessToken = config["Credentials:AccessToken"],
                AccessKey = config["Credentials:AccessKey"],
                ShipperId = config["Credentials:ShipperId"],
                web = "true"
            });

            return result;
        }

        public async Task<PagingResponse<tbl_client_headerDto>> GetPagedClientHeadersAsync<T>(PagingParameters paging)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paging.PageNumber.ToString(),
                ["pageSize"] = paging.PageSize.ToString()
            };

            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Data = paging,
                Url = SD.AddressBookApiBase + "?web=true",
                AccessToken = config["Credentials:AccessToken"],
                AccessKey = config["Credentials:AccessKey"],
                ShipperId = config["Credentials:ShipperId"],
                web = "true"
            });

            var pagingResponse = new PagingResponse<tbl_client_headerDto>
            {
                Items = JsonConvert.DeserializeObject<List<tbl_client_headerDto>>(result.ToString())
            };
            return pagingResponse;
        }

        public async Task<T> GetClientHeaderByIdAsync<T>(long id)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AddressBookApiBase + "/" + id,
                AccessToken = ""
            });
            return result;
        }

        public Task<T> UpdateClientHeaderAsync<T>(tbl_client_headerDto entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
