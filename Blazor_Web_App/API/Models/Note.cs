namespace API.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? IdContract { get; set; }
        public Contact? Contract { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
