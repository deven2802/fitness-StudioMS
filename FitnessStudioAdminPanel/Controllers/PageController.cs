using Microsoft.AspNetCore.Mvc;

namespace FitnessStudioAdminPanel.Controllers
{
	public class PageController : Controller
	{
		public IActionResult UserDetails()
		{
			return View();
		}

		public IActionResult Index()
		{
			return View();
		}

        public IActionResult Coaches()
        {
            return View();
        }

        public IActionResult StudioInfo()
        {
            return View();
        }

        public IActionResult PackageList()
        {
            return View();
        }

        public IActionResult Financial()
        {
            return View();
        }
    }
}
