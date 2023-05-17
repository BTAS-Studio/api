using BTAS.BlazorApp.Models.Dto;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Services.Interface
{
    public interface IContactDetailsService : IBaseService
    {
        Task<T> GetAllContactDetailsAsync<T>();
        Task<T> GetContactDetailsByIdAsync<T>(long id);
        Task<T> CreateContactDetailsAsync<T>(tbl_client_contact_detailsDto entity);
        Task<T> UpdateContactDetailsAsync<T>(tbl_client_contact_detailsDto entity);
        Task<T> DeleteContactDetailsAsync<T>(long id);
    }
}
