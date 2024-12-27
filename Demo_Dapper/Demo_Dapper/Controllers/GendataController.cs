using Demo_Dapper.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendataController(IEmployessService employessService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var result = await employessService.Getall();
            return Ok(result);
        }
    }
}
