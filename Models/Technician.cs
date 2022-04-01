using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class Technician : Person
    {
        [Key]
        public long TechnicianId { get; set; }

        /// <summary>
        /// Person's email address (optional)
        /// </summary>
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email is not valid.")]
        [Remote("VerifyEmail", "Technicians", ErrorMessage="Email is already in use.")]
        public string? EmailAddress { get; set; }
    }
}
