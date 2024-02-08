using AbweAddressBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace AbweAddressBook.Controllers
{
    public class ContactController : Controller
    {
        private ContactContext Context { get; set; }

        public ContactController(ContactContext ctx) => Context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Contact());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            Contact? contact = Context.Contacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0)
                {
                    Context.Contacts.Add(contact);
                }
                else
                {
                    Context.Contacts.Update(contact);
                }
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (contact.ContactId == 0) ? "Add" : "Edit";
                return View(contact);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Contact? contact = Context.Contacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            Context.Contacts.Remove(contact);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Contact? contact = Context.Contacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Details(Contact contact)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
