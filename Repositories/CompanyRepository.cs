using Microsoft.EntityFrameworkCore;
using POC.EF.SqlServer.API.Context;
using POC.EF.SqlServer.API.Entities;
using POC.EF.SqlServer.API.Repositories.Interfaces;

namespace POC.EF.SqlServer.API.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _context.Companies.Include(company => company.Employees).ToListAsync();
        }

        public async Task<Company> GetById(int id)
        {
            return await _context.Companies.Include(company => company.Employees)
                .AsNoTracking().FirstOrDefaultAsync(company => company.Id == id);
        }

        public async Task<Company> Insert(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> Update(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> Delete(Company company)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return company;
        }
    }
}
