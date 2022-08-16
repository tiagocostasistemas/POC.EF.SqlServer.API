using POC.EF.SqlServer.API.DTOs.Employee;

namespace POC.EF.SqlServer.API.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponse>> GetAll();
        Task<EmployeeResponse> GetById(int id);
        Task<EmployeeResponse> Insert(EmployeeRequest request);
        Task<EmployeeResponse> Update(EmployeeRequest request);
        Task<EmployeeResponse> Delete(int id);
    }
}
