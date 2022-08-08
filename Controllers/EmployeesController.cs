using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POC.EF.SqlServer.API.Data.Context;
using POC.EF.SqlServer.API.DTOs.Employee;
using POC.EF.SqlServer.API.Entities;
using POC.EF.SqlServer.API.Helpers.Mappers;

namespace POC.EF.SqlServer.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var employees = await context.Employees.Include(employee => employee.Company).ToListAsync();

            var employeesDTO = EmployeeMapper.Map(employees);

            return Ok(employeesDTO);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context,
                                                      [FromRoute] int id)
        {
            var employee = await context.Employees.Include(employee => employee.Company)
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (employee is null) return NotFound();

            var employeeDTO = EmployeeMapper.Map(employee);

            return employeeDTO is null ? NotFound() : Ok(employeeDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] AppDbContext context,
                                                   [FromBody] EmployeeRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var company = await context.Companies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.CompanyId);

            if (company is null)
                return BadRequest();

            var employee = new Employee()
            {
                Name = request.Name,
                Position = request.Position,
                Salary = request.Salary,
                CompanyId = company.Id
            };

            try
            {
                await context.Employees.AddAsync(employee);
                await context.SaveChangesAsync();
                return Created($"v1/employees/{employee.Id}", null);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context,
                                                  [FromBody] EmployeeRequest request,
                                                  [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employee = await context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (employee is null)
                return NotFound();

            employee.Name = request.Name;
            employee.Position = request.Position;
            employee.Salary = request.Salary;
            employee.CompanyId = request.CompanyId;

            try
            {
                context.Employees.Update(employee);
                await context.SaveChangesAsync();
                return Ok(employee);
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
            var employee = await context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (employee is null)
                return NotFound();

            try
            {
                context.Employees.Remove(employee);
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
