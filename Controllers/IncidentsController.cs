using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assignment1.Models;
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
        [HttpGet]
        [Route("incidents")]
        [Route("incidents/{filter?}")]
        public async Task<IActionResult> Index(string filter)
        {
            var incidents = await _context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .ToListAsync();

            if (filter == "open") {
                incidents = incidents.Where(i => i.isOpen).ToList();
            }
            else if (filter == "unassigned") {
                incidents = incidents.Where(i => i.isUnassigned).ToList();
            }

            return View(new IncidentViewModel() {
                PageTitle = "Incidents",
                Incidents = incidents,
            });
        }

        [HttpGet]
        [Route("incidents/details/{id}")]
        public async Task<IActionResult> Details(long id)
        {
            Incident? incident = await _context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .FirstOrDefaultAsync(m => m.IncidentId == id);

            if (incident == null)
                { return NotFound(); }

            return View(
                new IncidentViewModel() {
                    Incident = incident,
                    CustomerId = incident.CustomerId,
                    Customer = incident.Customer,
                    ProductId = incident.ProductId,
                    Product = incident.Product,
                    TechnicianId = incident.TechnicianId,
                    Technician = incident.Technician,
                    Title = incident.Title,
                    Description = incident.Description,
                    DateOpened = incident.DateOpened,
                    DateClosed = incident.DateClosed
                }
            );
        }

        // GET: Incidents/Create
        [HttpGet]
        [Route("incidents/create")]
        public IActionResult Create()
        {
            return View(
                new IncidentViewModel() {
                    Customers = (
                        from c in _context.Customers
                        orderby c.Name
                        select new SelectListItem(c.Name, c.CustomerId.ToString())
                    ),
                    Products = (
                        from p in _context.Products
                        orderby p.Name
                        select new SelectListItem(p.Name, p.ProductId.ToString())
                    ),
                    Technicians = (
                        from t in _context.Technicians
                        orderby t.Name
                        select new SelectListItem(t.Name, t.TechnicianId.ToString())
                    )
                }
            );
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("incidents/create")]
        public async Task<IActionResult> Create(Incident incident)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incident);
                await _context.SaveChangesAsync();
                TempData["AlertMessage-successful"] = "Customer ID " + incident.CustomerId + " incident file Created Successfully!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(
                    new IncidentViewModel() {
                        Customers = (
                            from c in _context.Customers
                            orderby c.Name
                            select new SelectListItem(c.Name, c.CustomerId.ToString())
                        ),
                        Products = (
                            from p in _context.Products
                            orderby p.Name
                            select new SelectListItem(p.Name, p.ProductId.ToString())
                        ),
                        Technicians = (
                            from t in _context.Technicians
                            orderby t.Name
                            select new SelectListItem(t.Name, t.TechnicianId.ToString())
                        )
                    }
                );
            }
        }

        [HttpGet]
        [Route("incidents/edit/{id?}")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                { return NotFound(); }

            var incident = await _context.Incidents.FindAsync(id);

            if (incident == null)
                { return NotFound(); }

            incident.Customer = await _context.Customers.FindAsync(incident.CustomerId);
            incident.Product = await _context.Products.FindAsync(incident.ProductId);
            incident.Technician = await _context.Technicians.FindAsync(incident.TechnicianId);

            return View(
                new IncidentViewModel() {
                    Incident = incident,
                    IncidentId = incident.IncidentId,
                    CustomerId = incident.CustomerId,
                    ProductId = incident.ProductId,
                    TechnicianId = incident.TechnicianId,
                    Title = incident.Title,
                    Description = incident.Description,
                    DateOpened = incident.DateOpened,
                    DateClosed = incident.DateClosed,

                    Customers = (
                        from c in _context.Customers
                        orderby c.Name
                        select new SelectListItem(c.Name, c.CustomerId.ToString())
                    ),
                    Products = (
                        from p in _context.Products
                        orderby p.Name
                        select new SelectListItem(p.Name, p.ProductId.ToString())
                    ),
                    Technicians = (
                        from t in _context.Technicians
                        orderby t.Name
                        select new SelectListItem(t.Name, t.TechnicianId.ToString())
                    )
                }
            );
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("incidents/edit/{id?}")]
        public async Task<IActionResult> Edit(long id, Incident incident)
        {
            if (id != incident.IncidentId)
            {
                return NotFound();
            }


            incident.Customer = await _context.Customers.FindAsync(incident.CustomerId);
            incident.Product = await _context.Products.FindAsync(incident.ProductId);
            incident.Technician = await _context.Technicians.FindAsync(incident.TechnicianId);

            if (ModelState.IsValid)
            {
                Console.WriteLine($"url id: {id} | form id: {incident.IncidentId}, {incident.Customer}");
                try
                {
                    _context.Update(incident);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage-important"] = $"Customer {incident.Customer.Name} incident file updated! Check the details!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentExists(incident.IncidentId))
                        { return NotFound(); }
                    else
                        { throw; }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(
                new IncidentViewModel() {
                    Incident = incident,
                    IncidentId = incident.IncidentId,
                    CustomerId = incident.CustomerId,
                    ProductId = incident.ProductId,
                    TechnicianId = incident.TechnicianId,
                    Title = incident.Title,
                    Description = incident.Description,
                    DateOpened = incident.DateOpened,
                    DateClosed = incident.DateClosed,

                    Customers = (
                        from c in _context.Customers
                        orderby c.Name
                        select new SelectListItem(c.Name, c.CustomerId.ToString())
                    ),
                    Products = (
                        from p in _context.Products
                        orderby p.Name
                        select new SelectListItem(p.Name, p.ProductId.ToString())
                    ),
                    Technicians = (
                        from t in _context.Technicians
                        orderby t.Name
                        select new SelectListItem(t.Name, t.TechnicianId.ToString())
                    )
                }
            );
        }

        // GET: Incidents/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
                { return NotFound(); }

            var incident = await _context.Incidents.FirstOrDefaultAsync(m => m.IncidentId == id);

            if (incident == null)
                { return NotFound(); }

            return View(
                new IncidentViewModel() {
                    Incident = incident,
                    CustomerId = incident.CustomerId,
                    Customer = incident.Customer,
                    ProductId = incident.ProductId,
                    Product = incident.Product,
                    TechnicianId = incident.TechnicianId,
                    Technician = incident.Technician,
                    Title = incident.Title,
                    Description = incident.Description,
                    DateOpened = incident.DateOpened,
                    DateClosed = incident.DateClosed,
                });
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();
            TempData["AlertMessage-delete"] = $"Customer ID {incident.CustomerId} incident file deleted!";
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentExists(long id)
        {
            return _context.Incidents.Any(e => e.IncidentId == id);
        }
    }

    public static class MvcExtensions
    {
        public static string ActiveClass(
            this IHtmlHelper htmlHelper,
            string controllers = null,
            string actions = null,
            string cssClass = "active"
        )
        {
            var currentController = htmlHelper?.ViewContext.RouteData.Values["controller"] as string;
            var currentAction = htmlHelper?.ViewContext.RouteData.Values["action"] as string;

            var acceptedControllers = (controllers ?? currentController ?? "").Split(',');
            var acceptedActions = (actions ?? currentAction ?? "").Split(',');

            return (
                acceptedControllers.Contains(currentController) && acceptedActions.Contains(currentAction)
                ? cssClass : ""
            );
        }
    }

}
