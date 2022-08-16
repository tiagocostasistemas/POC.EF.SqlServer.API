using POC.EF.SqlServer.API.DTOs.Company;

namespace POC.EF.SqlServer.API.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyResponse>> GetAll();
        Task<CompanyResponse> GetById(int id);
        Task<CompanyResponse> Insert(CompanyRequest request);
        Task<CompanyResponse> Update(CompanyRequest request);
        Task<CompanyResponse> Delete(int id);
    }
}
