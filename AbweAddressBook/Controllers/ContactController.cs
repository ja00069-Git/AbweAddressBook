using AbweAddressBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace AbweAddressBook.Controllers;

/// <summary>
///     The controller for the contact pages.
///     Jabesi Abwe
///     02/07/2024
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
public class ContactController : Controller
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ContactController" /> class.
    /// </summary>
    /// <param name="ctx">The CTX.</param>
    public ContactController(ContactContext ctx)
    {
        Context = ctx;
    }

    /// <summary>
    ///     Gets the Contact Context.
    /// </summary>
    /// <value>
    ///     The context.
    /// </value>
    private ContactContext Context { get; }

    /// <summary>
    ///     Adds a new contact.
    /// </summary>
    /// <returns>Details of the added contact</returns>
    public IActionResult Add()
    {
        ViewBag.Action = "Add";
        ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
        return View("Edit", new Contact());
    }

    /// <summary>
    ///     Adds the specified contact.
    /// </summary>
    /// <param name="contact">The contact.</param>
    /// <returns>Details of the added contact</returns>
    [HttpPost]
    public IActionResult Add(Contact contact)
    {
        if (ModelState.IsValid)
        {
            if (IsDuplicateContact(contact))
            {
                ModelState.AddModelError("", "A contact with the same information already exists.");
                ViewBag.Action = "Add";
                ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
                return View("Edit", contact);
            }

            Context.Contacts.Add(contact);
            Context.SaveChanges();
            return RedirectToAction("Details", new { id = contact.ContactId });
        }

        ViewBag.Action = "Add";
        ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
        return View("Edit", contact);
    }

    /// <summary>
    ///     Edits the specified contact.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>The details of the edited contact</returns>
    [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewBag.Action = "Edit";
        ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
        var contact = Context.Contacts.Find(id);
        return View(contact);
    }

    /// <summary>
    ///     Edits the specified contact.
    /// </summary>
    /// <param name="contact">The contact.</param>
    /// <returns>The details of the edited contact</returns>
    [HttpPost]
    public IActionResult Edit(Contact contact)
    {
        if (ModelState.IsValid)
        {
            if (IsDuplicateContact(contact))
            {
                ModelState.AddModelError("", "A contact with the same information already exists.");
                ViewBag.Action = "Edit";
                ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
                return View(contact);
            }

            if (contact.ContactId == 0)
                Context.Contacts.Add(contact);
            else
                Context.Contacts.Update(contact);
            Context.SaveChanges();
            return RedirectToAction("Details", new { id = contact.ContactId });
        }

        ModelState.Remove("CategoryId");

        if (contact.CategoryId <= 0) ModelState.AddModelError("CategoryId", "Please select a category.");

        ViewBag.Action = "Edit";
        ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
        return View(contact);
    }

    private bool IsDuplicateContact(Contact contact)
    {
        return Context.Contacts.Any(c =>
            c.LastName == contact.LastName &&
            c.PhoneNumber == contact.PhoneNumber &&
            c.CategoryId == contact.CategoryId);
    }

    /// <summary>
    ///     Deletes the specified contact.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>To the home page</returns>
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var contact = Context.Contacts.Find(id);
        return View(contact);
    }

    /// <summary>
    ///     Deletes the specified contact.
    /// </summary>
    /// <param name="contact">The contact.</param>
    /// <returns>To the home page</returns>
    [HttpPost]
    public IActionResult Delete(Contact contact)
    {
        Context.Contacts.Remove(contact);
        Context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }

    /// <summary>
    ///     Details of specified contact.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>The Details</returns>
    [HttpGet]
    public IActionResult Details(int id)
    {
        ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
        var contact = Context.Contacts.Find(id);
        return View(contact);
    }
}