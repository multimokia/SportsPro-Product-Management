using System.ComponentModel.DataAnnotations;
namespace assignment1.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }

        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
