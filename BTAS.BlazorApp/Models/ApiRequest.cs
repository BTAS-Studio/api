using static BTAS.BlazorApp.SD;

namespace BTAS.BlazorApp.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string ShipperId { get; set; }
        public string AccessKey { get; set; }
        public string AccessToken { get; set; }
        public string web { get; set; } = "false";
    }
}
