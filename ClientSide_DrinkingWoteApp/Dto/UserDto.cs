using System.Text.Json.Serialization;

namespace ClientSide_DrinkingWoteApp.Dto
{
    public class UserDto
    {
        public string User_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? BirthTime { get; set; }
    }
}
