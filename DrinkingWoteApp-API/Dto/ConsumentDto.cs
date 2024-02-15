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
        public Address? Address { get; set; }
        public User? User { get; set; }
    }
}
