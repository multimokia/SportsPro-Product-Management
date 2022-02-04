using System;
using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class Technician : Person
    {
        [Key]
        public long TechnicianId { get; set; }

        public Technician(
            string firstName,
            string lastName,
            string streetAddress,
            string city,
            string postalCode,
            string country,
            string? emailAddress=null,
            string? phoneNumber=null
        )
        {
            //Use current datetime in milliseconds as the id for simplicity
            TechnicianId = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            FirstName = firstName;
            LastName = lastName;
            StreetAddress = streetAddress;
            City = city;
            PostalCode = postalCode;
            Country = country;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }
    }
}
