using Getdata.DTO;
using Getdata.Models;
using Getdata.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Getdata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetdataController(IDataService dataService) : ControllerBase
    {
        [HttpGet("employess")]
        public async Task<IActionResult> Getemployess()
        {
            var result = await dataService.GetData();
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateData(CreateData dto)
        {
            try
            {
                var result = await dataService.CreateData(dto.EntityType, dto.JsonData);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployess(Guid id)
        {
            var delete = await dataService.DeleteData(id);
            return Ok(delete);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmployess(CreateData createData)
        {
            try
            {
                var result = await dataService.UpdateEmployess(createData.EntityType, createData.JsonData);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }

}
