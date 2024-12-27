using Data_Select.Service;
using Microsoft.AspNetCore.Mvc;

namespace Data_Select.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WeatherForecastController(ISmartSoftService smartSoftService) : ControllerBase
    {
        [HttpGet("getdata")]
        public async Task<IActionResult> GetData(string tableName, string condition = null, string columns = null)
        {
            try
            {
                var param = new { Parameter = "Employess", Condition = condition, Colums = tableName };
                var results = await smartSoftService.GetListObjectAsync<object>("GetData", param);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        
    }
}
