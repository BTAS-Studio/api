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
    public class DynamicFilterService : BaseService, IDynamicFilterService
    {
        private readonly IHttpClientFactory _client;
        private IConfiguration config;

        public DynamicFilterService(IHttpClientFactory client, IConfiguration config) : base(client)
        {
            _client = client;
            this.config = config;
        }

        public Task<T> CreateDynamicFilterAsync<T>(tbl_dynamic_filterDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> DeleteDynamicFilterAsync<T>(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> GetAllDynamicFiltersAsync<T>()
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

        public async Task<PagingResponse<tbl_dynamic_filterDto>> GetPagedDynamicFiltersAsync<T>(PagingParameters paging)
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

            var pagingResponse = new PagingResponse<tbl_dynamic_filterDto>
            {
                Items = JsonConvert.DeserializeObject<List<tbl_dynamic_filterDto>>(result.ToString())
            };
            return pagingResponse;
        }

        public async Task<T> GetDynamicFilterByIdAsync<T>(long id)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AddressBookApiBase + "/" + id,
                AccessToken = ""
            });
            return result;
        }

        public Task<T> UpdateDynamicFilterAsync<T>(tbl_dynamic_filterDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetFiltersByUser<T>(string user)
        {
            throw new System.NotImplementedException();
        }
    }
}
