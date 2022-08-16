using POC.EF.SqlServer.API.Entities;

namespace POC.EF.SqlServer.API.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();   
        Task<Employee> GetById(int id);
        Task<Employee> Insert(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<Employee> Delete(Employee employee);

    }
}
