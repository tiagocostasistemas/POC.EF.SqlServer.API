using POC.EF.SqlServer.API.DTOs.Address;
using Refit;

namespace POC.EF.SqlServer.API.Services
{
    public interface IViaCepService
    {
        [Get("/{zipcode}/json/")]
        Task<AddressResponse> GetByZipcode(int zipcode);
    }
}
