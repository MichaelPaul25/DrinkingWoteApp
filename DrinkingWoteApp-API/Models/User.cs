using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingWoteApp_API.Models
{
    public class User : IdentityUser
    {
        public string? User_Name { get; set;}
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
