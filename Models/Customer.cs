using System;
using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class Customer : Person
    {
        [Key]
        public long CustomerId { get; set; }
    }
}
