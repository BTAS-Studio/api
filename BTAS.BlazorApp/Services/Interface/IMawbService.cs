using BTAS.BlazorApp.Models;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Services.Interface
{
    public interface IMawbService : IBaseService
    {
        Task<T> GetMawbByReferenceAsync<T>(string reference);
        Task<T> GetAllAsync<T>();
        Task<T> GetAllAsync<T>(SearchFilter filter);
    }
}
