using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
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
            ViewBag.Customers = (
                from c in _context.Customers
                orderby c.Name
                select new SelectListItem(c.Name, c.CustomerId.ToString())
            );

            ViewBag.Products = new List<Product>();
            if (customerId != null)
            {
                Customer c = await _context.Customers.FindAsync(customerId);

                //Sanity check if customer exists
                if (c == null)
                    { return NotFound(); }

                ViewBag.Products = await _context.Products.Where(
                    p => c.ProductIds.Contains(p.ProductId)
                ).ToListAsync();
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
