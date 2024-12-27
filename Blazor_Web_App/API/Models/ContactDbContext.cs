using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Note> notes { get; set; }
    }
}

