using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Dto
{
    public class HomePageDataDto
    {
        public IEnumerable<Order> Orders { get; set; }
        public QuickCountDto QuickCount { get; set; }
    }
}
