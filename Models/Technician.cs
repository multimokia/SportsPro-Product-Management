using System;
using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class Technician : Person
    {
        [Key]
        public long TechnicianId { get; set; }


    }
}
