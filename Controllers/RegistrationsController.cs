using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assignment1.Models;
using System.Web;
using assignment1.ViewModels;

namespace assignment1.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly ProductContext context1;
        public RegistrationsController(ProductContext context)
        {
            context1 = context;
        }
        [HttpGet]
        [Route("registrations")]
        [Route("registrations/{filter?}")]
        public async Task<IActionResult> Index(string filter)
        {
            var registrations = await context1.Registrations
                .Include(i => i.Customer)
                //.Include(i => i.Product)
                .ToListAsync();

            //registrations = registrations.Where(i => {
            //    if (filter == "open")
            //    { return i.isOpen; }
            //    else if (filter == "unassigned")
            //    { return i.isUnassigned; }
            //    else
            //    { return true; }
            //}).ToList();

            return View(registrations);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }

}
