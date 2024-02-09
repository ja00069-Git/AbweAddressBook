using Microsoft.EntityFrameworkCore;

namespace AbweAddressBook.Models;

public class ContactContext : DbContext
{
    public ContactContext(DbContextOptions<ContactContext> options) : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                ContactId = 1,
                FirstName = "Henry",
                LastName = "Abwe",
                NickName = "Tiger",
                PhoneNumber = "123-456-7890",
                DateCreated = new DateTime(2023, 12, 20)
            },
            new Contact
            {
                ContactId = 2,
                FirstName = "Honore",
                LastName = "Kiza",
                NickName = "Baba",
                PhoneNumber = "124-379-5860",
                DateCreated = new DateTime(2024, 1, 30)
            },
            new Contact
            {
                ContactId = 3,
                FirstName = "UWG",
                LastName = "Carrollton",
                NickName = "JS",
                PhoneNumber = "140-256-7893",
                DateCreated = new DateTime(2024, 2, 7)
            }
        );
    }
}