using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Repository.Interface
{
    public interface IAuthenticationRepository
    {
        Task<string> ValidateTokenAsync(string apikey, string token, string shipperId);
    }
}
