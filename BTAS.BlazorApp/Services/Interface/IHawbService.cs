using BTAS.BlazorApp.Models;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Services.Interface
{
    public interface IHawbService : IBaseService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetByReferenceAsync<T>(string reference);
        Task<T> GetByMawbReferenceAsync<T>(string reference);
    }
}
