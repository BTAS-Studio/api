using BTAS.BlazorApp.Extensions;
using BTAS.BlazorApp.Models.Dto;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Services.Interface
{
    public interface IClientHeaderService : IBaseService
    {
        Task<T> GetAllClientHeadersAsync<T>();
        Task<PagingResponse<tbl_client_headerDto>> GetPagedClientHeadersAsync<T>(PagingParameters paging);
        Task<T> GetClientHeaderByIdAsync<T>(long id);
        Task<T> CreateClientHeaderAsync<T>(tbl_client_headerDto entity);
        Task<T> UpdateClientHeaderAsync<T>(tbl_client_headerDto entity);
        Task<T> DeleteClientHeaderAsync<T>(long id);
    }
}
