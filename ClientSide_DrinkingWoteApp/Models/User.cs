using System.ComponentModel.DataAnnotations;

namespace ClientSide_DrinkingWoteApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? User_Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public int? ConsumentId { get; set; }
        public Consument? Consument { get; set; }
        public string? MobilePhone { get; set; }
        public DateTime? BirthTime { get; set; }
    }
}
