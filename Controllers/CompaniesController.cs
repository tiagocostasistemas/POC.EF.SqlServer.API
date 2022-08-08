using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POC.EF.SqlServer.API.Data.Context;
using POC.EF.SqlServer.API.DTOs.Company;
using POC.EF.SqlServer.API.Entities;
using POC.EF.SqlServer.API.Helpers.Mappers;

namespace POC.EF.SqlServer.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var companies = await context.Companies.Include(company => company.Employees).ToListAsync();
            var companiesResponse = CompanyMapper.Map(companies);

            return Ok(companiesResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context,
                                                      [FromRoute] int id)
        {
            var company = await context.Companies.Include(company => company.Employees)
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (company is null) return NotFound();

            var companyResponse = CompanyMapper.Map(company);

            return companyResponse is null ? NotFound() : Ok(companyResponse);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] AppDbContext context,
                                                   [FromBody] CompanyRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var company = new Company()
            {
                Name = request.Name,
                Street = request.Street,
                Number = request.Number,
                Complement = request.Complement,
                District = request.District,
                City = request.City,
                State = request.State,
                ZipCode = request.ZipCode,
                Phone = request.Phone,
            };

            try
            {
                await context.Companies.AddAsync(company);
                await context.SaveChangesAsync();
                return Created($"v1/companies/{company.Id}", company);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context,
                                                  [FromBody] CompanyRequest request,
                                                  [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var company = await context.Companies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (company is null)
                return NotFound();

            company.Name = request.Name;
            company.Street = request.Street;
            company.Number = request.Number;
            company.Complement = request.Complement;
            company.District = request.District;
            company.City = request.City;
            company.State = request.State;
            company.ZipCode = request.ZipCode;
            company.Phone = request.Phone;

            try
            {
                context.Companies.Update(company);
                await context.SaveChangesAsync();
                return Ok(company);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context,
                                                     [FromRoute] int id)
        {
            var company = await context.Companies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (company is null)
                return NotFound();

            try
            {
                context.Companies.Remove(company);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
