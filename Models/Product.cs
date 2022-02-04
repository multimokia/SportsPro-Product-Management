using System;
using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class Product
    {
        [Key]
        [Required(ErrorMessage="Product code is required")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage="Product name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage="A yearly price is required")]
        public double YearlyPrice { get; set; }

        [Required(ErrorMessage="Product release date is required")]
        public DateTime ReleaseDate { get; set; }
    }
}
