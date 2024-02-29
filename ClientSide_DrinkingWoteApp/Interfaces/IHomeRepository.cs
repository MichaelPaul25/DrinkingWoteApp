using ClientSide_DrinkingWoteApp.Dto;

namespace ClientSide_DrinkingWoteApp.Interfaces
{
    public interface IHomeRepository
    {
        Task<HomePageDataDTO?> GetHomePageData();
    }
}
