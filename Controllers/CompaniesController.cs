using Microsoft.AspNetCore.Mvc;
using POC.EF.SqlServer.API.Context;
using POC.EF.SqlServer.API.DTOs.Company;
using POC.EF.SqlServer.API.Services.Interfaces;

namespace POC.EF.SqlServer.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompaniesController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var companies = await _service.GetAll();
            return companies is null ? NotFound() : Ok(companies);
        }
       

        [HttpGet("{id}", Name = "GetCompanyByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var company = await _service.GetById(id);
            return company is null ? NotFound() : Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CompanyRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();

            var company = await _service.Insert(request);
            return company is null ? BadRequest() : Created($"GetCompanyByIdAsync/{company.Id}", company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] CompanyRequest request, int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var company = await _service.Update(request);
            return company is null ? NotFound() : Ok(company);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context, int id)
        {
            var company = await _service.Delete(id);
            return company is null ? NotFound() : Ok(company);
        }
    }
}
