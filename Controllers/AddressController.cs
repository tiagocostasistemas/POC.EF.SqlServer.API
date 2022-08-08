using Microsoft.AspNetCore.Mvc;
using POC.EF.SqlServer.API.Services;

namespace POC.EF.SqlServer.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        [HttpGet("{zipcode}")]
        public async Task<IActionResult> GetByZipcodeAsync([FromServices] IViaCepService service,
                                                           [FromRoute] int zipcode)
        {
            var addreess = await service.GetByZipcode(zipcode);
            return Ok(addreess);
        }
    }
}
