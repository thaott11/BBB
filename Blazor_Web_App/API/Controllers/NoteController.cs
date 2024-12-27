using API.Models;
using API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController(INoteService noteService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var result = await noteService.Getdata();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            var Createnote = await noteService.Create(note);
            return Ok(Createnote);
        }
    }
}
