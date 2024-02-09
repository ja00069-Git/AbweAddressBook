using AbweAddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbweAddressBook.Controllers;

public class HomeController : Controller
{
    public HomeController(ContactContext ctx)
    {
        Context = ctx;
    }

    private ContactContext Context { get; }

    public IActionResult Index()
    {
        IList<Contact> contacts = Context.Contacts.Include(ca => ca.Category).OrderBy(c => c.LastName)
            .ThenBy(c => c.FirstName).ToList();
        return View(contacts);
    }
}