using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    /// <summary>
    /// Base class for a person.
    /// This class should be inherited by upper level classes which need to store personal information.
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// First name of the person
        /// </summary>
        [Required(ErrorMessage="First name is required")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the person
        /// </summary>
        [Required(ErrorMessage="Last name is required")]
        public string LastName { get; set; }

        /// <summary>
        /// Street address of the person, (no country/city/postal code)
        /// </summary>
        [Required(ErrorMessage="Address is required")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Person's city
        /// </summary>
        [Required(ErrorMessage="City is required")]
        public string City { get; set; }

        /// <summary>
        /// Person's postal code
        /// </summary>
        [Required(ErrorMessage="Postal code is required")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Person's country
        /// </summary>
        [Required(ErrorMessage="Country is required")]
        public string Country { get; set; }

        /// <summary>
        /// Person's email address (optional)
        /// </summary>
        public string? EmailAddress { get; set; }

        /// <summary>
        /// Person's phone number (optional)
        /// </summary>
        public string? PhoneNumber { get; set; }
    }
}
