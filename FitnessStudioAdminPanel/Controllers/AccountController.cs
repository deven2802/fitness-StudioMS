using FitnessStudioAdminPanel.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessStudioAdminPanel.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // In a real application, you would authenticate against your user store here.
            // For now, we'll skip authentication for simplicity.

            // Redirect to the Index action of HomeController after 'logging in'
            return RedirectToAction("Index", "Home");
        }
    }
}
