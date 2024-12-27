using Newtonsoft.Json;

namespace Blazor_Web_App.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string plane { get; set; }
        public bool Isdeleted { get; set; }
        public DateTime DateOfBird { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public DateTime DateDelete { get; set; }
        [JsonIgnore]
        public List<Note> Node { get; set; } = new List<Note>();
    }
}
