using dapper.Models;
using Dapper2;
using Dapper2.Service;
using Microsoft.AspNetCore.Mvc;

namespace dapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(IEmployService service) : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };



        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var result = await service.GetList();

            return Ok(result);
        }
    }
}
