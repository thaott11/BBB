namespace WEB_APP.Models
{
    public class company
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Name { get; set; }

        public string? Address { get; set; }
    }
}
