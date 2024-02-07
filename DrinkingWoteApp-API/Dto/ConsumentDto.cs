using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Dto
{
    public class ConsumentDto
    {
        public int ConsumentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? JoinDate { get; set; }
        public float? Balance { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public Address? Address { get; set; }
        public ICollection<Bill>? Bills { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
