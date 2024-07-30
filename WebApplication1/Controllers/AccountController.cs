using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login ()
        {
            return PartialView("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login (UserViewModel User)
        {
            if (User.UserName == "Manar" &&  User.Password == "Manar")
            {
                return RedirectToAction("ShowAll", "Instructor");
            }
            return PartialView("Login" , User);
        }
    }
}
