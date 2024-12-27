using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Service
{
    public class ContactService(ContactDbContext _db) : IContactService

    {
        public async Task<Contact> Create(Contact contact)
        {
            _db.contacts.Add(contact);
            await _db.SaveChangesAsync();
            return contact;
        }

        public async Task Delete(int id)
        {
            var finid = await _db.contacts.FindAsync(id);
            if (finid != null)
            {
               _db.contacts.Remove(finid);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Contact> Getbyid(int id)
        {
            return await _db.contacts.FindAsync(id);
        }

        public async Task<IEnumerable<Contact>> Getdata()
        {
            return await _db.contacts.ToListAsync();
        }

        public async Task<IEnumerable<Contact>> SearchContacts(string? firstname, string? lastname, string? plane)
        {
            var query = _db.contacts.AsQueryable();

            if (!string.IsNullOrEmpty(firstname))
            {
                query = query.Where(c => c.Firstname.Trim().ToLower().Contains(firstname.ToLower()));
            }

            if (!string.IsNullOrEmpty(lastname))
            {
                query = query.Where(x => x.Lastname.Trim().ToLower().Contains(lastname.ToLower()));
            }

            if (!string.IsNullOrEmpty(plane))
            {
                query = query.Where(x => x.plane.Trim().ToLower().Contains(plane.ToLower()));
            }
            return await query.ToListAsync();
        }

        public async Task<Contact> Update(Contact contact)
        {
            _db.contacts.Update(contact);   
            await _db.SaveChangesAsync();
            return contact;
        }
    }
}
