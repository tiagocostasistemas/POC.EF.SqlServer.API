using Microsoft.EntityFrameworkCore;
using POC.EF.SqlServer.API.Context;
using POC.EF.SqlServer.API.Entities;
using POC.EF.SqlServer.API.Repositories.Interfaces;

namespace POC.EF.SqlServer.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {   
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.Include(employee => employee.Company).ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.Include(employee => employee.Company)
                .AsNoTracking().FirstOrDefaultAsync(employee => employee.Id == id);
        }

        public async Task<Employee> Insert(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> Update(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee> Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}
