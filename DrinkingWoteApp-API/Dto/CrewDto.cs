using DrinkingWoteApp_API.Models;
using System.ComponentModel.DataAnnotations;

namespace DrinkingWoteApp_API.Dto
{
    public class CrewDto
    {
        public int CrewId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CrewStatus { get; set; }
    }
}
