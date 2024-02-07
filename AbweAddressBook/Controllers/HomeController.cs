using Microsoft.AspNetCore.Mvc;

namespace AbweAddressBook.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      
    }
}
