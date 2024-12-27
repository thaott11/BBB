using API.Models;
using API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(IContactService contactService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Getdata()
        {
            var contact = await contactService.Getdata();
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            var create = await contactService.Create(contact);
            return Ok(create);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var finid = await contactService.Getbyid(id);
            return Ok(finid);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Contact contact)
        {
            var existingContact = await contactService.Getbyid(id);
            if (existingContact == null)
            {
                return NotFound(new { Message = $"Contact with ID {id} not found." });
            }
            existingContact.Firstname = contact.Firstname;
            existingContact.Lastname = contact.Lastname;
            existingContact.Nickname = contact.Nickname;
            existingContact.plane = contact.plane;
            existingContact.Isdeleted = contact.Isdeleted;
            existingContact.DateOfBird = contact.DateOfBird;
            existingContact.DateCreate = contact.DateCreate;

            var updatedContact = await contactService.Update(existingContact);
            return Ok(updatedContact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await contactService.Getbyid(id);
            if (contact == null)
            {
                return NotFound();
            }

            await contactService.Delete(id);
            return Ok();
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchContacts([FromQuery] string? firstname, [FromQuery] string? lastname, [FromQuery] string? plane)
        {
            var results = await contactService.SearchContacts(firstname, lastname, plane);
            return Ok(results);
        }

    }
}
