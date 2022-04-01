using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment1.Models
{
    public class Incident
    {
        [Key]
        public long IncidentId { get; set; }

        [Display(Name="Customer")]
        [Required(ErrorMessage = "The customer involved is required.")]
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Display(Name="Product")]
        [Required(ErrorMessage = "A product selection is required.")]
        public string ProductId { get; set; }
        public Product Product { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        #nullable enable
        [Display(Name="Technician Assigned")]
        public long? TechnicianId { get; set; }
        public Technician? Technician { get; set; }
        #nullable restore

        [Display(Name="Date Opened")]
        [Required(ErrorMessage = "Open date is required.")]
        public DateTime DateOpened { get; set; } = DateTime.Now.Date;

        [Display(Name="Date Closed")]
        public DateTime? DateClosed { get; set; }

        //Filterable statuses
        [NotMapped]
        public bool isOpen => DateClosed == null;

        [NotMapped]
        public bool isUnassigned => TechnicianId == null;
    }
}
