using AbweAddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbweAddressBook.Controllers;

/// <summary>
/// The controller for the home page.
/// Jabesi Abwe
/// 02/08/2024
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
public class HomeController : Controller
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HomeController"/> class.
    /// </summary>
    /// <param name="ctx">The CTX.</param>
    public HomeController(ContactContext ctx)
    {
        Context = ctx;
    }

    /// <summary>
    /// Gets the Contact Context.
    /// </summary>
    /// <value>
    /// The context.
    /// </value>
    private ContactContext Context { get; }

    public IActionResult Index()
    {
        IList<Contact> contacts = Context.Contacts.Include(ca => ca.Category).OrderBy(c => c.LastName)
            .ThenBy(c => c.FirstName).ToList();
        return View(contacts);
    }
}