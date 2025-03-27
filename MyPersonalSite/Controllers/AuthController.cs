using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MyPersonalSite.Controllers
{
    public class AuthController : Controller
    {
        private const string Username = "admin"; // Hardcoded username
        private const string Password = "password123"; // Hardcoded password

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == Username && password == Password)
            {
                HttpContext.Session.SetString("User", username); // Store session data
                return RedirectToAction("ProtectedPage", "Home"); // Redirect to protected content
            }
            else
            {
                ViewBag.Message = "Invalid login credentials.";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User"); // Clear session data
            return RedirectToAction("Login");
        }
    }
}
