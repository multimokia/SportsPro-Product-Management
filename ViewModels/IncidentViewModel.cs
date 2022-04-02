using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

using assignment1.Models;

namespace assignment1.ViewModels
{
    public class IncidentViewModel : PageModel
    {
        public string PageTitle { get; set; }

        //Stuff needed for populating the dropdown lists
        public IList<Incident> Incidents { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
        public IEnumerable<SelectListItem> Technicians { get; set; }

        //Parts for the forms
        [Display(Name="Customer")]
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Display(Name="Product")]
        public string ProductId { get; set; }
        public Product Product { get; set; }

        #nullable enable
        [Display(Name="Technician")]
        public long? TechnicianId { get; set; }
        public Technician? Technician { get; set; }

        [Display(Name="Date Closed")]
        public DateTime? DateClosed { get; set; }
        #nullable restore

        [Required(ErrorMessage="An incident title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage="A brief description of the incident is required.")]
        public string Description { get; set; }

        [Display(Name="Date Opened")]
        public DateTime DateOpened { get; set; } = DateTime.Now.Date;

        //Hold an incident for editing/viewing
        public long IncidentId { get; set; }
        public Incident Incident { get; set; }
    }
}
