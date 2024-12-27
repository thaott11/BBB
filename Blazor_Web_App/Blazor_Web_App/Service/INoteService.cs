using System.Collections;
using Blazor_Web_App.Pages;

namespace Blazor_Web_App.Service
{
    public interface INoteService
    {
        Task<List<Note>> GetAllNote();
        Task<Note> CreateContact(Note note);
    }
}
