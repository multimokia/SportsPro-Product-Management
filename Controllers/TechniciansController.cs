using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assignment1.Models;

namespace assignment1.Controllers
{
    public class TechniciansController : Controller
    {
        private readonly ProductContext _context;

        public TechniciansController(ProductContext context)
        {
            _context = context;
        }

        // GET: Technicians
        public async Task<IActionResult> Index()
        {
            return View(await _context.Technicians.ToListAsync());
        }

        // GET: Technicians/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technician = await _context.Technicians
                .FirstOrDefaultAsync(m => m.TechnicianId == id);
            if (technician == null)
            {
                return NotFound();
            }

            return View(technician);
        }

        // GET: Technicians/Create
        public IActionResult Create()
        {
            ViewBag.Countries = CustomersController.Countries;
            return View();
        }

        // POST: Technicians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Technician technician)
        {
            if (ModelState.IsValid)
            {
                _context.Add(technician);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Countries = CustomersController.Countries;
            return View(technician);
        }

        // GET: Technicians/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                { return NotFound(); }

            var technician = await _context.Technicians.FindAsync(id);
            if (technician == null)
                { return NotFound(); }

            ViewBag.Countries = CustomersController.Countries;
            return View(technician);
        }

        // POST: Technicians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Technician technician)
        {
            if (id != technician.TechnicianId)
                { return NotFound(); }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(technician);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechnicianExists(technician.TechnicianId))
                        { return NotFound(); }
                    else
                        { throw; }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Countries = CustomersController.Countries;
            return View(technician);
        }

        // GET: Technicians/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technician = await _context.Technicians
                .FirstOrDefaultAsync(m => m.TechnicianId == id);
            if (technician == null)
            {
                return NotFound();
            }

            return View(technician);
        }

        // POST: Technicians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var technician = await _context.Technicians.FindAsync(id);
            _context.Technicians.Remove(technician);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechnicianExists(long id)
        {
            return _context.Technicians.Any(e => e.TechnicianId == id);
        }

        /// <summary>
        /// Validation for email address. Verifies the email provided is not already in the database for technicians
        /// </summary>
        /// <param name="email">email address to check</param>
        /// <returns>Json object</returns>
        [HttpGet]
        public JsonResult VerifyEmail(string EmailAddress)
        {
            return Json(
                !_context.Technicians.Any(t => t.EmailAddress == EmailAddress)
            );
        }
    }
}
