using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using assignment1.Models;

namespace assignment1.ViewModels
{
    public class CustomerViewModel
    {
        public Person Customer { get; set; }

        public List<Customer> Customers { get; } = new List<Customer>
        {
            new Customer { City = "Toronto", Country = "Canada", CustomerId = 1, EmailAddress = "aggra", Name = "Test Test", PhoneNumber = "25436253", PostalCode = "gsrge", StreetAddress = " 23424 2" }
        };
    }
}
