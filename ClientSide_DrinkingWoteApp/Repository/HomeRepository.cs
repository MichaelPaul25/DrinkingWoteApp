using ClientSide_DrinkingWoteApp.Dto;
using ClientSide_DrinkingWoteApp.Interfaces;
using Newtonsoft.Json;

namespace ClientSide_DrinkingWoteApp.Repository
{
    public class HomeRepository : IHomeRepository
    {
        Uri baseAddress = new Uri("https://localhost:7280/api");
        private readonly HttpClient _client;
        public HomeRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public async Task<HomePageDataDTO?> GetHomePageData()
        {
            HomePageDataDTO dataDTO = new HomePageDataDTO();

            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Order/GetHomePageData").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                dataDTO = JsonConvert.DeserializeObject<HomePageDataDTO>(data);
            }

            return dataDTO;
        }
    }
}
