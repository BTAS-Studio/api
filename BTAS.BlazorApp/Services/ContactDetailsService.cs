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
    public class ContactDetailsService : BaseService, IContactDetailsService
    {
        private readonly IHttpClientFactory _client;
        private IConfiguration config;

        public ContactDetailsService(IHttpClientFactory client, IConfiguration config) : base(client)
        {
            _client = client;
            this.config = config;
        }

        public Task<T> CreateContactDetailsAsync<T>(tbl_client_contact_detailsDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> DeleteContactDetailsAsync<T>(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> GetAllContactDetailsAsync<T>()
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ContactDetailsApiBase + "?web=true",
                AccessToken = config["Credentials:AccessToken"],
                AccessKey = config["Credentials:AccessKey"],
                ShipperId = config["Credentials:ShipperId"],
                web = "true"
            });

            return result;
        }

        public async Task<T> GetContactDetailsByIdAsync<T>(long id)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ContactDetailsApiBase + "/" + id,
                AccessToken = ""
            });
            return result;
        }

        public Task<T> UpdateContactDetailsAsync<T>(tbl_client_contact_detailsDto entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
