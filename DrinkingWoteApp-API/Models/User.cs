using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingWoteApp_API.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        [Required]
        public string User_Name { get; set;}
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [ForeignKey("Consumen_Id")]
        public Consumen? Consumen { get; set; }
        public string? MobilePhone { get; set; }
        public DateTime? BirthTime { get; set; }
    }
}
