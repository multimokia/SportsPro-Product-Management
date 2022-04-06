using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using assignment1.Models;

namespace assignment1.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly ProductContext _context;

        public RegistrationsController(ProductContext context)
        {
            _context = context;
        }

        [Route("/registrations/{customerId?}")]
        public async Task<IActionResult> Index(long? customerId)
        {
            ViewBag.Customers = await _context.Customers.Include(c => c.ProductIds).ToListAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
