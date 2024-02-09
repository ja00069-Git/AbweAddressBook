using AbweAddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AbweAddressBook.Controllers;

public class ContactController : Controller
{
    public ContactController(ContactContext ctx)
    {
        Context = ctx;
    }

    private ContactContext Context { get; }

    public IActionResult Add()
    {
        ViewBag.Action = "Add";
        ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
        return View("Edit", new Contact());
    }

    [HttpPost]
    public IActionResult Add(Contact contact)
    {
        if (ModelState.IsValid)
        {
            Context.Contacts.Add(contact);
            Context.SaveChanges();
            return RedirectToAction("Details", new { id = contact.ContactId });
        }

        ViewBag.Action = "Add";
        ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
        return View("Edit", contact);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewBag.Action = "Edit";
        ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
        Contact? contact = Context.Contacts.Find(id);
        return View(contact);
    }

    [HttpPost]
    public IActionResult Edit(Contact contact)
    {
        if (ModelState.IsValid)
        {
            if (contact.ContactId == 0 & !Context.Contacts.Contains(contact))
                Context.Contacts.Add(contact);
            else
                Context.Contacts.Update(contact);
            Context.SaveChanges();
            return RedirectToAction("Details", new { id = contact.ContactId });
        }
        else
        {
            ModelState.Remove("CategoryId");

            if (contact.CategoryId <= 0)
            {
                ModelState.AddModelError("CategoryId", "Please select a category.");
            }

            ViewBag.Action = "Edit";
            ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
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
        ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
        Contact? contact = Context.Contacts.Find(id);
        return View(contact);
    }
}