﻿using System;
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
    public class IncidentsController : Controller
    {
        private readonly ProductContext _context;

        public IncidentsController(ProductContext context)
        {
            _context = context;
        }

        // GET: Incidents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Incidents.ToListAsync());
        }

        // GET: Incidents/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incidents.FirstOrDefaultAsync(m => m.IncidentId == id);

            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // GET: Incidents/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.OrderBy((x) => x.Name).ToList();
            ViewBag.Products = _context.Products.OrderBy((x) => x.Name).ToList();
            ViewBag.Technicians = _context.Technicians.OrderBy((x) => x.Name).ToList();

            return View(new Incident());
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("IncidentId,Title,Description,DateOpened,DateClosed")] Incident incident
        )
        {
            ViewBag.Customers = _context.Customers.OrderBy((x) => x.Name).ToList();
            ViewBag.Products = _context.Products.OrderBy((x) => x.Name).ToList();
            ViewBag.Technicians = _context.Technicians.OrderBy((x) => x.Name).ToList();

            if (ModelState.IsValid)
            {
                _context.Add(incident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incident);
        }

        // GET: Incidents/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }

            ViewBag.Customers = _context.Customers.OrderBy((x) => x.Name).ToList();
            ViewBag.Products = _context.Products.OrderBy((x) => x.Name).ToList();
            ViewBag.Technicians = _context.Technicians.OrderBy((x) => x.Name).ToList();
            return View(incident);
        }

        // POST: Incidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IncidentId,Title,Description,DateOpened,DateClosed")] Incident incident)
        {
            if (id != incident.IncidentId)
            {
                return NotFound();
            }

            ViewBag.Customers = _context.Customers.OrderBy((x) => x.Name).ToList();
            ViewBag.Products = _context.Products.OrderBy((x) => x.Name).ToList();
            ViewBag.Technicians = _context.Technicians.OrderBy((x) => x.Name).ToList();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentExists(incident.IncidentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(incident);
        }

        // GET: Incidents/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incidents.FirstOrDefaultAsync(m => m.IncidentId == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentExists(long id)
        {
            return _context.Incidents.Any(e => e.IncidentId == id);
        }
    }
}
