using DrinkingWoteApp_API.Models;
using System.ComponentModel.DataAnnotations;

namespace DrinkingWoteApp_API.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string User_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobilePhone { get; set; }
        public DateTime BirthTime { get; set; }
        public int? ConsumentId { get; set; }
    }
}
