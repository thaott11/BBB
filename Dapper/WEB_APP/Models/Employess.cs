namespace WEB_APP.Models
{
    public class Employess
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? NameEmploy { get; set; }

        public int? Age { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }
    }
}
