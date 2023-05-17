using System.Threading.Tasks;

namespace BTAS.BlazorApp.Services.Interface
{
    public interface IDynamicFilterService : IBaseService
    {
        Task<T> GetFiltersByUser<T>(string user);
    }
}
