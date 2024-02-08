using AbweAddressBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace AbweAddressBook.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext Context { get; set; }

        public HomeController(ContactContext ctx) => Context = ctx;

        public IActionResult Index()
        {
            IList<Contact> contacts = Context.Contacts.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();
            return View(contacts);
        }
      
    }
}
