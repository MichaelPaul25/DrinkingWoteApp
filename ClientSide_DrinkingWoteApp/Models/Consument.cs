using System.ComponentModel.DataAnnotations;

namespace ClientSide_DrinkingWoteApp.Models
{
    public class Consument
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public User? User { get; set; }
        public DateTime? JoinDate { get; set; }
        public float? Balance { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public Address? Address { get; set; }
        public ICollection<Bill>? Bills { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
