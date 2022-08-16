using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POC.EF.SqlServer.API.Context;
using POC.EF.SqlServer.API.DTOs.Employee;
using POC.EF.SqlServer.API.Entities;
using POC.EF.SqlServer.API.Helpers.Mappers;
using POC.EF.SqlServer.API.Services.Interfaces;

namespace POC.EF.SqlServer.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var employees = await _service.GetAll();
            return employees is null ? NotFound() : Ok(employees);
        }


        [HttpGet("{id}", Name = "GetEmployeeByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var employee = await _service.GetById(id);
            return employee is null ? NotFound() : Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] EmployeeRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();

            var employee = await _service.Insert(request);
            return employee is null ? BadRequest() : Created($"GetEmployeeByIdAsync/{employee.Id}", employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] EmployeeRequest request, int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var employee = await _service.Update(request);
            return employee is null ? NotFound() : Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var employee = await _service.Delete(id);
            return employee is null ? NotFound() : Ok(employee);
        }
    }
}
