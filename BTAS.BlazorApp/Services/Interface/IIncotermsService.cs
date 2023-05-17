using BTAS.BlazorApp.Models.Dto;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Services.Interface
{
    public interface IIncotermsService : IBaseService
    {
        Task<T> GetAllIncotermsAsync<T>();
    }
}
