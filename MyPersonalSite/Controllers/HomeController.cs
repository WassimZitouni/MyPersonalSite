using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Required for session handling
using MyPersonalSite.Models;

namespace MyPersonalSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Hobbies()
        {
            return View();
        }

        public IActionResult Goals()
        {
            return View();
        }

        public IActionResult ProtectedPage()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                return RedirectToAction("Login", "Auth"); // Redirect to login if not authenticated
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
