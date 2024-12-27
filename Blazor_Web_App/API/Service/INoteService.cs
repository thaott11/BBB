using API.Models;

namespace API.Service
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> Getdata();
        Task<Note> Getbyid(int id);
        Task<Note> Create(Note note);
        Task<Note> Update(Note note);
        Task Delete(int id);
    }
}
