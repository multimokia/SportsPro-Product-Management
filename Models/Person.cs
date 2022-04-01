using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment1.Models
{
    /// <summary>
    /// Base class for a person.
    /// This class should be inherited by upper level classes which need to store personal information.
    /// </summary>
    [NotMapped]
    public abstract class Person
    {
        /// <summary>
        /// Full name of the person
        /// /// </summary>
        [Required(ErrorMessage="Name is required.")]
        [Display]
        public string Name { get; set; }

        /// <summary>
        /// Street address of the person, (no country/city/postal code)
        /// </summary>
        [Required(ErrorMessage="Address is required.")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Person's city
        /// </summary>
        [Required(ErrorMessage="City is required.")]
        public string City { get; set; }

        /// <summary>
        /// Person's postal code
        /// </summary>
        [Required(ErrorMessage="Postal code is required.")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Person's country
        /// </summary>
        [Required(ErrorMessage="Country is required.")]
        public string Country { get; set; }

        #nullable enable
        /// <summary>
        /// Person's email address (optional)
        /// </summary>
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email is not valid.")]
        public string? EmailAddress { get; set; }

        /// <summary>
        /// Person's phone number (optional)
        /// </summary>
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(\d{3}\)-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in format '(xxx)-xxx-xxx'.")]
        public string? PhoneNumber { get; set; }

        #nullable restore
    }
}
