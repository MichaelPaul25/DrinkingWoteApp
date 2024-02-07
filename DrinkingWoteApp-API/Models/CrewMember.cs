using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingWoteApp_API.Models
{
    public class CrewMember
    {
        [Key]
        public int CrewId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName{ get; set; }
        public ICollection<Order>? Orders { get; set; }
        public string? CrewStatus { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
