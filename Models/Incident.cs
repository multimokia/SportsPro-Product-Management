using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment1.Models
{
    public class Incident
    {
        [Key]
        public long IncidentId { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Product is required")]
        public string ProductId { get; set; }
        public Product Product { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        #nullable enable
        public long? TechnicianId { get; set; }
        public Technician? Technician { get; set; }
        #nullable restore

        [Display(Name="Date Opened")]
        public DateTime? DateOpened { get; set; }

        [Display(Name="Date Closed")]
        [Required(ErrorMessage = "Date Closed is required")]
        public DateTime DateClosed { get; set; }

        //Filterable statuses
        [NotMapped]
        public bool isOpen => DateClosed == null;

        [NotMapped]
        public bool isUnassigned => TechnicianId == null;
    }
}
