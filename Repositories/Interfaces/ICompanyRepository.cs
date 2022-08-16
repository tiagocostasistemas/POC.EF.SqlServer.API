using POC.EF.SqlServer.API.Entities;

namespace POC.EF.SqlServer.API.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetById(int id);
        Task<Company> Insert(Company company);
        Task<Company> Update(Company company);
        Task<Company> Delete(Company company);
    }
}
