using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class Customer : Person
    {
        [Key]
        public long CustomerId { get; set; }

        /// <summary>
        /// Person's email address (optional)
        /// </summary>

        #nullable enable
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.\w+)+)", ErrorMessage = "Email is not valid.")]
        [Remote("VerifyEmail", "customers", ErrorMessage="Email is already in use.")]
        public string? EmailAddress { get; set; }

        #nullable restore
    }
}
