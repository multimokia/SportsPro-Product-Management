using System;
using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class Product
    {
        [Key]
        [Required(ErrorMessage="Product code is required")]
        public string ProductId { get; set; } // Product code

        [Required(ErrorMessage="Product name is required")]
        public string Name { get; set; }

        [Display(Name="Yearly Price")]
        [Required(ErrorMessage="A yearly price is required")]
        public double YearlyPrice { get; set; }

        [Display(Name="Release Date")]
        [Required(ErrorMessage="Product release date is required")]
        public DateTime ReleaseDate { get; set; } = DateTime.Now.Date;
    }
}
