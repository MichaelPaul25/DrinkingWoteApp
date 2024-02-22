using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClientSide_DrinkingWoteApp.Models
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
