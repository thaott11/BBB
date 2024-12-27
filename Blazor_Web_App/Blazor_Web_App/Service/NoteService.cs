using System.Net.Http.Json;
using Blazor_Web_App.Pages;

namespace Blazor_Web_App.Service
{
    public class NoteService(HttpClient http) : INoteService
    {
        public async Task<Note> CreateContact(Note note)
        {
            var respones = await http.PostAsJsonAsync("/api/Note", note);
            if(respones.IsSuccessStatusCode)
            {
                return note;
            }
            return null;
        }

        public async Task<List<Note>> GetAllNote()
        {
            var result = await http.GetFromJsonAsync<IEnumerable<Note>>("/api/Note");
            return result?.ToList() ?? new List<Note>();
        }

    }
}
