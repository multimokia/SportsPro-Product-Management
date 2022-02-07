using System;
using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class Incident
    {
        [Key]

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Date Opened is required")]
        public DateTime DateOpened { get; set; }

        [Required(ErrorMessage = "Date closed is required")]
        public DateTime DateClosed { get; set; }
    }
}
