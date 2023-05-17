using BTAS.BlazorApp.Models;
using System;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Services.Interface
{
    public interface IBaseService : IDisposable
    {
        ResponseDto response { get; set; }
        Task<T> SendAsync<T>(ApiRequest ApiRequest);
    }
}
