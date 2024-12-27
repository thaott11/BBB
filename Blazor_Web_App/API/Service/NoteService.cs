using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Service
{
    public class NoteService(ContactDbContext _db) : INoteService
    {
        public async Task<Note> Create(Note note)
        {
            _db.notes.Add(note);
            await _db.SaveChangesAsync();
            return note;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Note> Getbyid(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Note>> Getdata()
        {
            return await _db.notes.ToListAsync();
        }

        public Task<Note> Update(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
