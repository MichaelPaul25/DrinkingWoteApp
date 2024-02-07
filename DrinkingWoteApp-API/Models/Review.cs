using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingWoteApp_API.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int? RatingStar { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [ForeignKey("OrderId")]
        public int? Order_Id { get; set; }
        public CrewMember? Crew { get; set; }

    }
}
