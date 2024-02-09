using Microsoft.EntityFrameworkCore;

namespace AbweAddressBook.Models;

/// <summary>
///     The contact context.
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
public class ContactContext : DbContext
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ContactContext" /> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public ContactContext(DbContextOptions<ContactContext> options) : base(options)
    {
    }

    /// <summary>
    ///     Gets or sets the contacts.
    /// </summary>
    /// <value>
    ///     The contacts.
    /// </value>
    public DbSet<Contact> Contacts { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the categories
    /// </summary>
    /// <value>
    ///     The categories
    /// </value>
    public DbSet<Category> Categories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Family" },
            new Category { CategoryId = 2, Name = "Friend" },
            new Category { CategoryId = 3, Name = "Work" }
        );

        modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                ContactId = 1,
                FirstName = "Henry",
                LastName = "Abwe",
                NickName = "Tiger",
                CategoryId = 1,
                PhoneNumber = "(123) 456-7890",
                DateCreated = new DateTime(2023, 12, 20)
            },
            new Contact
            {
                ContactId = 2,
                FirstName = "Honore",
                LastName = "Kiza",
                NickName = "Baba",
                CategoryId = 2,
                PhoneNumber = "(124) 379-5860",
                DateCreated = new DateTime(2024, 1, 30)
            },
            new Contact
            {
                ContactId = 3,
                FirstName = "UWG",
                LastName = "Carrollton",
                CategoryId = 3,
                PhoneNumber = "(140) 256-7893",
                DateCreated = new DateTime(2024, 2, 7)
            }
        );
    }
}