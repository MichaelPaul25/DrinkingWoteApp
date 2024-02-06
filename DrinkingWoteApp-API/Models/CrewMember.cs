using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingWoteApp_API.Models
{
    public class CrewMember
    {
        [Key]
        public int Crew_Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName{ get; set; }
        [ForeignKey("Order_Id")]
        public virtual ICollection<Order>? Orders { get; set; }
        public string? CrewStatus { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
