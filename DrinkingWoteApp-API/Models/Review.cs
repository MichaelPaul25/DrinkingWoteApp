using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingWoteApp_API.Models
{
    public class Review
    {
        [Key]
        public int Review_Id { get; set; }
        [ForeignKey("Order_Id")]
        public Order Order { get; set; }
        public int? RatingStar { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [ForeignKey("Crew_Id")]
        public CrewMember Crew { get; set; }

    }
}
