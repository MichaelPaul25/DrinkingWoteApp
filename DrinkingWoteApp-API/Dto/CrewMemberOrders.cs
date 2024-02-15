using DrinkingWoteApp_API.Models;
using System.ComponentModel.DataAnnotations;

namespace DrinkingWoteApp_API.Dto
{
    public class CrewMemberOrders
    {
        public int CrewId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public string? CrewStatus { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
