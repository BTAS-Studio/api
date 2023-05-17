using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BTAS.BlazorApp.Models;
using BTAS.BlazorApp.Services.Interface;
using Newtonsoft.Json;

namespace BTAS.BlazorApp.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto response { get; set; }
        private IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
            this.response = new ResponseDto();
        }

        public async Task<T> SendAsync<T>(ApiRequest ApiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("BTASClient");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.Headers.Add("apikey", ApiRequest.AccessKey);
                message.Headers.Add("apiToken", ApiRequest.AccessToken);
                message.Headers.Add("shipperId", ApiRequest.ShipperId);
                message.Headers.Add("web", "true");
                message.RequestUri = new Uri(ApiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (ApiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(ApiRequest.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage apiResponse = null;
                switch (ApiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                };

                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);

                return apiResponseDto;
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.Message.ToString() },
                    DisplayMessage = "Error"
                };

                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);

                return apiResponseDto;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
