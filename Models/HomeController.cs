using Microsoft.AspNetCore.Mvc;

namespace assignment1.Models
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
