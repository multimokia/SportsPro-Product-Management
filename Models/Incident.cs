using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;


namespace assignment1.Models
{
    public class Incident
    {
        [Key]

        public long IncidentId { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Customer Customer { get; set;}

        [Required(ErrorMessage = "Product is required")]
        public Product Product { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public Technician? Technician { get; set; }

        public DateTime? DateOpened { get; set; }
        [Required(ErrorMessage = "Date Closed is required")]
        public DateTime DateClosed { get; set; }
    }
}
