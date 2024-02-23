using ClientSide_DrinkingWoteApp.Models;

namespace ClientSide_DrinkingWoteApp.Dto
{
    public class HomePageDataDTO
    {
        public IEnumerable<Order> Orders { get; set; }
        public QuickCountDto QuickCount { get; set; }
    }
}
